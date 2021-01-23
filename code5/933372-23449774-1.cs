	List<string> list = new List<string>(System.IO.File.ReadAllLines(@"D:\ips.txt"));
	List<IPAddress> listIPAdrrs = new List<IPAddress>();
	for (int i = 0; i < list.Count; i++)
	{
		//Console.WriteLine(list[i]);
		listIPAdrrs.Add(IPAddress.Parse(list[i]));
	}
