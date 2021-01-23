    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace Reflection.IL
    {
        public struct ILInstruction
        {
            public OpCode Code { get; private set; }
            public object Operand { get; private set; }
    
            internal ILInstruction(OpCode code, object operand)
                : this()
            {
                this.Code = code;
                this.Operand = operand;
            }
    
            public int Size
            {
                get { return this.Code.Size + GetOperandSize(this.Code.OperandType); }
            }
    
            public override string ToString()
            {
                return this.Operand == null ? this.Code.ToString() : string.Format(CultureInfo.InvariantCulture, "{0} {1}", this.Code, this.Operand);
            }
    
            private static int GetOperandSize(OperandType operandType)
            {
                switch (operandType)
                {
                    case OperandType.InlineBrTarget:
                    case OperandType.InlineField:
                    case OperandType.InlineI:
                    case OperandType.InlineMethod:
                    case OperandType.InlineSig:
                    case OperandType.InlineString:
                    case OperandType.InlineSwitch:
                    case OperandType.InlineTok:
                    case OperandType.InlineType:
                        return sizeof(int);
    
                    case OperandType.InlineI8:
                        return sizeof(long);
    
                    case OperandType.InlineNone:
                        return 0;
    
                    case OperandType.InlineR:
                        return sizeof(double);
    
                    case OperandType.InlineVar:
                        return sizeof(short);
    
                    case OperandType.ShortInlineBrTarget:
                    case OperandType.ShortInlineI:
                    case OperandType.ShortInlineVar:
                        return sizeof(byte);
    
                    case OperandType.ShortInlineR:
                        return sizeof(float);
    
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    
        public sealed class MethodBodyIL : IEnumerable<ILInstruction>
        {
            private readonly MethodBase method;
    
            public MethodBodyIL(MethodBase method)
            {
                if (method == null)
                    throw new ArgumentNullException("method");
    
                this.method = method;
            }
    
            public Enumerator GetEnumerator()
            {
                var body = this.method.GetMethodBody();
    
                return new Enumerator(this.method.Module, this.method.DeclaringType.GetGenericArguments(), this.method.GetGenericArguments(), body.GetILAsByteArray(), body.LocalVariables);
            }
    
            IEnumerator<ILInstruction> IEnumerable<ILInstruction>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
    
            public struct Enumerator : IEnumerator<ILInstruction>
            {
                private static readonly IDictionary<short, OpCode> codes = typeof(OpCodes).FindMembers(MemberTypes.Field, BindingFlags.Public | BindingFlags.Static, (m, criteria) => ((FieldInfo)m).FieldType == typeof(OpCode), null).Cast<FieldInfo>().Select(f => (OpCode)f.GetValue(null)).ToDictionary(c => c.Value);
    
                private readonly Module module;
                private readonly Type[] genericTypeArguments, genericMethodArguments;
                private readonly byte[] il;
                private readonly IList<LocalVariableInfo> localVariables;
    
                private int offset;
                private ILInstruction current;
    
                internal Enumerator(Module module, Type[] genericTypeArguments, Type[] genericMethodArguments, byte[] il, IList<LocalVariableInfo> localVariables)
                {
                    this.module = module;
                    this.genericTypeArguments = genericTypeArguments;
                    this.genericMethodArguments = genericMethodArguments;
                    this.il = il;
                    this.localVariables = localVariables;
    
                    this.offset = 0;
                    this.current = default(ILInstruction);
                }
    
                public ILInstruction Current
                {
                    get { return this.current; }
                }
    
                public bool MoveNext()
                {
                    if (this.offset < this.il.Length)
                    {
                        this.current = this.ReadInstruction();
                        return true;
                    }
                    else
                    {
                        this.current = default(ILInstruction);
                        return false;
                    }
                }
    
                public void Reset()
                {
                    this.offset = 0;
                    this.current = default(ILInstruction);
                }
    
                public void Dispose()
                {
                    this.offset = this.il.Length;
                    this.current = default(ILInstruction);
                }
    
                private ILInstruction ReadInstruction()
                {
                    var code = this.ReadCode();
    
                    return new ILInstruction(code, this.ReadOperand(code.OperandType));
                }
    
                private OpCode ReadCode()
                {
                    var code = codes[this.ReadByte()];
    
                    if (code.OpCodeType == OpCodeType.Prefix)
                        code = codes[(short)(code.Value << 8 | this.ReadByte())];
    
                    return code;
                }
    
                private object ReadOperand(OperandType operandType)
                {
                    switch (operandType)
                    {
                        case OperandType.InlineBrTarget:
                        case OperandType.InlineI:
                        case OperandType.InlineSwitch:
                            return this.ReadInt32();
    
                        case OperandType.InlineField:
                        case OperandType.InlineMethod:
                        case OperandType.InlineTok:
                        case OperandType.InlineType:
                            return this.ReadMember();
    
                        case OperandType.InlineI8:
                            return this.ReadInt64();
    
                        case OperandType.InlineNone:
                            return null;
    
                        case OperandType.InlineR:
                            return this.ReadDouble();
    
                        case OperandType.InlineSig:
                            return this.ReadSignature();
    
                        case OperandType.InlineString:
                            return this.ReadString();
    
                        case OperandType.InlineVar:
                            return this.ReadLocalVariable();
    
                        case OperandType.ShortInlineBrTarget:
                        case OperandType.ShortInlineI:
                            return this.ReadByte();
    
                        case OperandType.ShortInlineR:
                            return this.ReadSingle();
    
                        case OperandType.ShortInlineVar:
                            return this.ReadLocalVariableShort();
    
                        default:
                            throw new InvalidOperationException();
                    }
                }
    
                private byte ReadByte()
                {
                    var value = this.il[this.offset];
                    ++this.offset;
    
                    return value;
                }
    
                private short ReadInt16()
                {
                    var value = BitConverter.ToInt16(this.il, this.offset);
                    this.offset += sizeof(short);
    
                    return value;
                }
    
                private int ReadInt32()
                {
                    var value = BitConverter.ToInt32(this.il, this.offset);
                    this.offset += sizeof(int);
    
                    return value;
                }
    
                private long ReadInt64()
                {
                    var value = BitConverter.ToInt64(this.il, this.offset);
                    this.offset += sizeof(long);
    
                    return value;
                }
    
                private float ReadSingle()
                {
                    var value = BitConverter.ToSingle(this.il, this.offset);
                    this.offset += sizeof(float);
    
                    return value;
                }
    
                private double ReadDouble()
                {
                    var value = BitConverter.ToDouble(this.il, this.offset);
                    this.offset += sizeof(double);
    
                    return value;
                }
    
                private MemberInfo ReadMember()
                {
                    return this.module.ResolveMember(this.ReadInt32(), this.genericTypeArguments, this.genericMethodArguments);
                }
    
                private byte[] ReadSignature()
                {
                    return this.module.ResolveSignature(this.ReadInt32());
                }
    
                private string ReadString()
                {
                    return this.module.ResolveString(this.ReadInt32());
                }
    
                private LocalVariableInfo ReadLocalVariable()
                {
                    return this.localVariables[this.ReadInt16()];
                }
    
                private LocalVariableInfo ReadLocalVariableShort()
                {
                    return this.localVariables[this.ReadByte()];
                }
    
                object IEnumerator.Current
                {
                    get { return this.Current; }
                }
            }
        }
    
        public static class ILHelper
        {
            public static MethodBodyIL GetIL(this MethodBase method)
            {
                return new MethodBodyIL(method);
            }
    
            public static IEnumerable<MethodBase> GetCalledMethods(this Delegate methodPtr)
            {
                if (methodPtr == null)
                    throw new ArgumentNullException("methodPtr");
    
                foreach (var instruction in methodPtr.Method.GetIL())
                    if (IsMethodCall(instruction.Code))
                        yield return (MethodBase)instruction.Operand;
            }
    
            private static bool IsMethodCall(OpCode code)
            {
                return code == OpCodes.Call || code == OpCodes.Calli || code == OpCodes.Callvirt;
            }
        }
    }
