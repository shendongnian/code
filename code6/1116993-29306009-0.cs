       Console.WriteLine("What name would you like to use?(please enter in lower case)");
        string name = Console.ReadLine();
        string letter = name.Length > 0 ? name.Substring(0, 1): string.Empty;		
        string restofname = string.IsNullOrEmpty(letter) ? string.Empty : name.Substring(1);
		Console.WriteLine(restofname);
