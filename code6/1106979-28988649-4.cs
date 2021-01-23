    public static int GetSize(Type type, string arrayName, bool instance)
    {
        FieldInfo field = type.GetField(arrayName);
        var defaultContructor = typeof(MyClass).GetConstructor((instance ? BindingFlags.Instance : BindingFlags.Static) | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
        ConstructorInfo[] constructors;
        if (defaultContructor == null)
        {
            // Only a single static constructor :)
            if (!instance)
            {
                throw new Exception();
            }
            constructors = typeof(MyClass).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
        else
        {
            constructors = new[] { defaultContructor };
        }
        foreach (ConstructorInfo contructor in constructors)
        {
            var instructions = Mono.Reflection.Disassembler.GetInstructions(defaultContructor);
            int i;
            for (i = 0; i < instructions.Count; i++)
            {
                if ((instructions[i].Operand as FieldInfo) == field)
                {
                    break;
                }
            }
            if (i == instructions.Count)
            {
                continue;
            }
            if (i - 2 < 0)
            {
                throw new Exception();
            }
            OpCode newArr = instructions[i - 1].OpCode;
            if (newArr != OpCodes.Newarr)
            {
                throw new Exception();
            }
            var sizeInstruction = instructions[i - 2];
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
                throw new Exception();
            }
            return size;
        }
        throw new Exception();
    }
