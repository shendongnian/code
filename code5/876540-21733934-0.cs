	string s = "My. name. is Bond._James Bond!";
	int idx = s.LastIndexOf('.');
    if (idx != -1)
    {
	    Console.WriteLine(s.Substring(0, idx)); // "My. name. is Bond"
    	Console.WriteLine(s.Substring(idx + 1)); // "_James Bond!"
    }
