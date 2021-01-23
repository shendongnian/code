    public override ProblemCollection Check(TypeNode type)
    {
    	foreach (TypeNode nestedType in type.NestedTypes)
    	{
    		if (nestedType.NodeType == NodeType.Struct)
    			if(!type.Name.Name.Contains("Struct"))
    				Problems.Add(new Problem(new Resolution("FileNameIsIncorrect", type.Name.Name), type));
    				
    	}
    	return Problems;
    }
