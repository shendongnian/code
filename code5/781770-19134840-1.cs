    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    abstract class ILInstruction
    {
    }
    class SimpleInstruction : ILInstruction
    {
        public string Name { get; private set; }
        public SimpleInstruction(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return GetType().Name + " " + Name;
        }
    }
    abstract class MethodBaseInstruction : ILInstruction
    {
        public MethodBase Method { get; private set; }
        public MethodBaseInstruction(MethodBase method)
        {
            Method = method;
        }
        public override string ToString()
        {
            return GetType().Name + " " + Method.Name;
        }
    }
    class InlineNoneInstruction : MethodBaseInstruction
    {
        public int Offset { get; private set; }
        public OpCode OpCode { get; private set; }
        public InlineNoneInstruction(MethodBase method, int offset, OpCode opCode)
            : base(method)
        {
            Offset = offset;
            OpCode = opCode;
        }
        public override string ToString()
        {
            return base.ToString() + " " + Offset + " " + OpCode;
        }
    }
    class ShortInlineBrTargetInstruction : InlineNoneInstruction
    {
        public sbyte ShortDelta { get; private set; }
        public ShortInlineBrTargetInstruction(MethodBase method, int offset, OpCode opCode, sbyte shortDelta)
            : base(method, offset, opCode)
        {
            ShortDelta = shortDelta;
        }
        public override string ToString()
        {
            return base.ToString() + " " + ShortDelta;
        }
    }
    class InlineMethodInstruction : InlineNoneInstruction
    {
        public int Token { get; private set; }
        public InlineMethodInstruction(MethodBase method, int offset, OpCode opCode, int token)
            : base(method, offset, opCode)
        {
            Token = token;
        }
        public override string ToString()
        {
            return base.ToString() + " " + Token;
        }
    }
    class InlineSwitchInstruction : InlineNoneInstruction
    {
        public int[] Deltas { get; private set; }
        public InlineSwitchInstruction(MethodBase method, int offset, OpCode opCode, int[] deltas)
            : base(method, offset, opCode)
        {
            Deltas = deltas;
        }
        public override string ToString()
        {
            return base.ToString() + " " + string.Join(", ", Deltas);
        }
    }
    class ILReader : IEnumerable<ILInstruction>
    {
        Byte[] m_byteArray;
        Int32 m_position;
        MethodBase m_enclosingMethod;
        static OpCode[] s_OneByteOpCodes = new OpCode[0x100];
        static OpCode[] s_TwoByteOpCodes = new OpCode[0x100];
        static ILReader()
        {
            foreach (FieldInfo fi in typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                OpCode opCode = (OpCode)fi.GetValue(null);
                UInt16 value = (UInt16)opCode.Value;
                if (value < 0x100)
                    s_OneByteOpCodes[value] = opCode;
                else if ((value & 0xff00) == 0xfe00)
                    s_TwoByteOpCodes[value & 0xff] = opCode;
            }
        }
        public ILReader(MethodBase enclosingMethod)
        {
            this.m_enclosingMethod = enclosingMethod;
            MethodBody methodBody = m_enclosingMethod.GetMethodBody();
            this.m_byteArray = (methodBody == null) ? new Byte[0] : methodBody.GetILAsByteArray();
            this.m_position = 0;
        }
        public IEnumerator<ILInstruction> GetEnumerator()
        {
            while (m_position < m_byteArray.Length)
                yield return Next();
            m_position = 0;
            yield break;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        ILInstruction Next()
        {
            Int32 offset = m_position;
            OpCode opCode = OpCodes.Nop;
            Int32 token = 0;
            // read first 1 or 2 bytes as opCode
            Byte code = ReadByte();
            if (code != 0xFE)
                opCode = s_OneByteOpCodes[code];
            else
            {
                code = ReadByte();
                opCode = s_TwoByteOpCodes[code];
            }
            switch (opCode.OperandType)
            {
                case OperandType.InlineNone:
                    return new InlineNoneInstruction(m_enclosingMethod, offset, opCode);
                case OperandType.ShortInlineBrTarget:
                    SByte shortDelta = ReadSByte();
                    return new ShortInlineBrTargetInstruction(m_enclosingMethod, offset, opCode, shortDelta);
                case OperandType.InlineBrTarget: Int32 delta = ReadInt32(); return new SimpleInstruction(delta.ToString());
                case OperandType.ShortInlineI: Byte int8 = ReadByte(); return new SimpleInstruction(int8.ToString());
                case OperandType.InlineI: Int32 int32 = ReadInt32(); return new SimpleInstruction(int32.ToString());
                case OperandType.InlineI8: Int64 int64 = ReadInt64(); return new SimpleInstruction(int64.ToString());
                case OperandType.ShortInlineR: Single float32 = ReadSingle(); return new SimpleInstruction(float32.ToString());
                case OperandType.InlineR: Double float64 = ReadDouble(); return new SimpleInstruction(float64.ToString());
                case OperandType.ShortInlineVar: Byte index8 = ReadByte(); return new SimpleInstruction(index8.ToString());
                case OperandType.InlineVar: UInt16 index16 = ReadUInt16(); return new SimpleInstruction(index16.ToString());
                case OperandType.InlineString: token = ReadInt32(); return new SimpleInstruction("InlineString" + token.ToString());
                case OperandType.InlineSig: token = ReadInt32(); return new SimpleInstruction("InlineSig" + token.ToString());
                case OperandType.InlineField: token = ReadInt32(); return new SimpleInstruction("InlineField" + token.ToString());
                case OperandType.InlineType: token = ReadInt32(); return new SimpleInstruction("InlineType" + token.ToString());
                case OperandType.InlineTok: token = ReadInt32(); return new SimpleInstruction("InlineTok" + token.ToString());
                case OperandType.InlineMethod:
                    token = ReadInt32();
                    return new InlineMethodInstruction(m_enclosingMethod, offset, opCode, token);
                case OperandType.InlineSwitch:
                    Int32 cases = ReadInt32();
                    Int32[] deltas = new Int32[cases];
                    for (Int32 i = 0; i < cases; i++) deltas[i] = ReadInt32();
                    return new InlineSwitchInstruction(m_enclosingMethod, offset, opCode, deltas);
                default:
                    throw new BadImageFormatException("unexpected OperandType " + opCode.OperandType);
            }
        }
        Byte ReadByte() { return (Byte)m_byteArray[m_position++]; }
        SByte ReadSByte() { return (SByte)ReadByte(); }
        UInt16 ReadUInt16() { m_position += 2; return BitConverter.ToUInt16(m_byteArray, m_position - 2); }
        UInt32 ReadUInt32() { m_position += 4; return BitConverter.ToUInt32(m_byteArray, m_position - 4); }
        UInt64 ReadUInt64() { m_position += 8; return BitConverter.ToUInt64(m_byteArray, m_position - 8); }
        Int32 ReadInt32() { m_position += 4; return BitConverter.ToInt32(m_byteArray, m_position - 4); }
        Int64 ReadInt64() { m_position += 8; return BitConverter.ToInt64(m_byteArray, m_position - 8); }
        Single ReadSingle() { m_position += 4; return BitConverter.ToSingle(m_byteArray, m_position - 4); }
        Double ReadDouble() { m_position += 8; return BitConverter.ToDouble(m_byteArray, m_position - 8); }
    }
