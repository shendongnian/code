	static void CreateEnumAssembly(string asmName, string relativePathName = "")
	{
		// get asm version from database
		Version asmVersion = new Version(0,0,0,0);
		AssemblyNameDefinition asmNameDef = new AssemblyNameDefinition(asmName, asmVersion);
		AssemblyDefinition asmDef = AssemblyDefinition.CreateAssembly (asmNameDef, asmName, ModuleKind.Dll);
		// get enum name from database
		string enumName = "myEnum";
		// define a new enum type
		TypeDefinition enumTypeDef;
		asmDef.MainModule.Types.Add (enumTypeDef = new TypeDefinition ( asmName, enumName, TypeAttributes.Public | TypeAttributes.Sealed, asmDef.MainModule.Import(typeof(System.Enum) )));
		// - add FlagsAttribute to the enum
		CustomAttribute flagsAttribute = new CustomAttribute ( asmDef.MainModule.Import(typeof(FlagsAttribute).GetConstructor(Type.EmptyTypes)) );
		enumTypeDef.CustomAttributes.Add( flagsAttribute );
		// define the special field "value__" of the enum
		enumTypeDef.Fields.Add (new FieldDefinition ("value__", FieldAttributes.Public | FieldAttributes.SpecialName | FieldAttributes.RTSpecialName, asmDef.MainModule.Import (typeof(System.Int32))));
		int shift = 0;
		// get literals and their values from database and define them in the enum
		foreach (var literalName in literalNames) 
		{
			FieldDefinition literalDef;
			enumTypeDef.Fields.Add (literalDef = new FieldDefinition (literalName, FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal | FieldAttributes.HasDefault, enumTypeDef));
			System.Int32 key = 1 << shift++;
			literalDef.Constant = key;
		}
		string filename = relativePathName+asmNameDef.Name+".dll";
		asmDef.Write(filename);
		Debug.Log ("Created assembly '"+filename+"'");
	}
