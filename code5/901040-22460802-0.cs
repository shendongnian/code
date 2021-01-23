    List<string> input = new List<string>();
	input.Add("Blue Code \n 03 ID \n 05 Example \n Sky is blue");
	input.Add("Green Code\n 01 ID\n 15");
	input.Add("Test TestCode \n 99 \n Testing is fun");
			
	foreach(string text in  input)
	{
		string rest = text;
		//1 Take first word
		string part1 = rest.Split(' ')[0];
		rest = rest.Skip(part1.Length).ToString();
		//while rest contains (/n number)
		while (rest.Contains("\n"))
		{
			//Take until /n number
			int index = rest.IndexOf("\n");
			string partNa = rest.Take(index).ToString();
			string temp = rest.Skip(index).ToString();
			string partNb = temp.Split(' ')[0];
			int n;
			if (int.TryParse("123", out n))
			{
				string partN = partNa + partNb;
				rest = rest.Skip(partN.Length).ToString();
			}
		}
		//Take rest
		string part3 = rest;
    }
