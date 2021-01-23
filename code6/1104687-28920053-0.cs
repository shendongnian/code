    // Get the OpcCodes using Reflection
    Type opCodes = typeof(OpCodes);
    var opCodesList = opCodes.GetFields(BindingFlags.Public | BindingFlags.Static)
    .Where(f => f.FieldType == typeof(OpCode))
    .Select(f => 
    {	OpCode opCode = (OpCode)f.GetValue(null);
    	return new {Name=f.Name, Instruction = opCode.Name, Size = opCode.Size, OpCode = string.Format("0x{0:X2}", opCode.Value) };
    });
    
    // Print to the Console
    var opCodesStrings = opCodesList
    .Select( o => string.Format("{0,-10}{1,-15}{2,-10}{3,-10}", o.Name, o.Instruction, o.Size, o.OpCode))
    .ToList();
    opCodesStrings.Insert(0, string.Format("{0,-10}{1,-15}{2,-10}{3,-10}", "Name", "Instruction", "Size", "OpCode"));
    opCodesStrings.Insert(1, string.Format("{0,-10}{1,-15}{2,-10}{3,-10}", "----", "-----------", "----", "------"));
    opCodesStrings.ForEach(Console.WriteLine);
