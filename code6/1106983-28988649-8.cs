    /// <summary>
    /// Supports only direct array sizing with values 0...int.MaxValue .
    /// Doesn't support: values greater than int.MaxValue, static values,
    /// function calling, ...
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arrayName"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public static int GetSize(Type type, string arrayName, bool instance)
    {
        BindingFlags bindingFlags = (instance ? BindingFlags.Instance : BindingFlags.Static) | BindingFlags.Public | BindingFlags.NonPublic;
        // The array
        FieldInfo arrayField = type.GetField(arrayName, bindingFlags);
        // We don't know which constructor does the initialization, so we 
        // check each one. We start with the first one, and then we will 
        // follow the chain of constructors
        ConstructorInfo constructor = typeof(MyClass).GetConstructors(bindingFlags).FirstOrDefault();
        while (constructor != null)
        {
            ConstructorInfo nextConstructor = null;
            var instructions = Mono.Reflection.Disassembler.GetInstructions(constructor);
            int i;
            for (i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].OpCode == OpCodes.Call)
                {
                    nextConstructor = instructions[i].Operand as ConstructorInfo;
                    // If there is a call to another constructor, then 
                    // this isn't the method we are looking for :-)
                    if (nextConstructor != null)
                    {
                        if (constructor.DeclaringType != nextConstructor.DeclaringType)
                        {
                            // Going to base class constructor without 
                            // initializing the field we are interested 
                            // in. We can stop looking.
                            nextConstructor = null;
                        }
                        i = instructions.Count;
                        break;
                    }
                }
                // We look for a Stfld operation on the array
                if (instructions[i].OpCode == OpCodes.Stfld && (instructions[i].Operand as FieldInfo) == arrayField)
                {
                    break;
                }
            }
            // Access to the array wasn't found. Let's look at the next 
            // constructor
            if (i == instructions.Count)
            {
                constructor = nextConstructor;
                continue;
            }
            // There are too few instructions before this array access
            if (i - 2 < 0)
            {
                throw new NotSupportedException();
            }
            OpCode newArr = instructions[i - 1].OpCode;
            // Is the previous instruction a NewArr?
            if (newArr != OpCodes.Newarr)
            {
                throw new NotSupportedException();
            }
            var sizeInstruction = instructions[i - 2];
            // Calc the size. There are various opcodes for this.
            int size;
            if (sizeInstruction.OpCode == OpCodes.Ldc_I4)
            {
                size = (int)sizeInstruction.Operand;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_0)
            {
                size = 0;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_1)
            {
                size = 1;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_2)
            {
                size = 2;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_3)
            {
                size = 3;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_4)
            {
                size = 4;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_5)
            {
                size = 5;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_6)
            {
                size = 6;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_7)
            {
                size = 7;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_8)
            {
                size = 8;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_M1)
            {
                size = -1;
            }
            else if (sizeInstruction.OpCode == OpCodes.Ldc_I4_S)
            {
                size = (sbyte)sizeInstruction.Operand;
            }
            else
            {
                // The size of the array was calculated in some other 
                // way. Not supported :-(
                throw new NotSupportedException();
            }
            return size;
        }
        throw new NotSupportedException();
    }
