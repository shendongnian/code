	Console.WriteLine("Please enter info in the following format");
	Console.WriteLine("ID Name Height Weight Status");
	
	data = Console.ReadLine();
	var info = data.Split(" ");
	c.Id = info[0];
	c.Insurance = info[1];
	c.Height = int.Parse(info[2]);
	
	etc...
	
