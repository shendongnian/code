	Assembly thisAssembly = Assembly.GetExecutingAssembly();
	StringBuilder OutputText ;
	OutputText = new StringBuilder();
	
	foreach (Type t in thisAssembly.GetTypes())
	{
		OutputText.AppendLine("\nPUBLIC MEMBERS FOR:" + t.FullName);
		MemberInfo[] Members = t.GetMembers(); 
		foreach (MemberInfo NextMember in Members) 
		{ 
			OutputText.AppendLine("\n\t" + NextMember.DeclaringType + " " + NextMember.MemberType + "  " + NextMember.Name); 
		} 
	}
	Console.WriteLine(OutputText); 
