    public void DeleteMember(string name)
    {
    	if (ML == null)
    	{
    		Console.WriteLine(name + " had not been added before.");
    	}
    	else
    	{
    		int memberIndex = ML.ToList().FindIndex(p => p.Name == name);
    		if (memberIndex = -1)
    		{
    			Console.WriteLine(name + " had not been added before.");
    			return;
    		}
    		List<Person> tmp = new List<Person>(ML);
    		tmp.RemoveAt(memberIndex);
    		ML = tmp.ToArray();
    	}
    }
