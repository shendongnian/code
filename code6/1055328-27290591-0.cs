    // sample "file":
    string fileContent = @"
    btn1 = 0,
    btn2 = 1,
    btn3 = 2,
    ";
    var enumBody = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => new { bothToken = line.Trim().Trim(',').Split('=') })
        .Where(x => x.bothToken.Length == 2)
        .Select(x => new { Name = x.bothToken[0].Trim(), Value = int.Parse(x.bothToken[1].Trim()) });
    AppDomain currentDomain = AppDomain.CurrentDomain;
    AssemblyName asmName = new AssemblyName("EnumAssembly");
    AssemblyBuilder asmBuilder = currentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder mb = asmBuilder.DefineDynamicModule(asmName.Name, asmName.Name + ".dll");
    string enumTypeName = string.Format("{0}.{1}", typeof(MyControls).Namespace, typeof(MyControls).Name);
    EnumBuilder eb = mb.DefineEnum(enumTypeName, TypeAttributes.Public, typeof(int));
    foreach(var element in enumBody)
    {
        FieldBuilder fb1 = eb.DefineLiteral(element.Name, element.Value);
    }
    Type eType = eb.CreateType();
    foreach (object obj in Enum.GetValues(eType))
    {
        Console.WriteLine("{0}.{1} = {2}", eType, obj, ((int)obj));
    }
