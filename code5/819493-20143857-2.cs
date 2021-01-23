	var key = Console.ReadKey(true);
	string keyInfo = string.Empty;
	byte keyInfoId = 0;
	switch (key.Key)
	{
		case ConsoleKey.F3: Console.WriteLine("F3 hit ..."); 
							keyInfo = "F3"; 
							keyInfoId = 0x3; 
							break;
		case ConsoleKey.F5: Console.WriteLine("F5 hit ..."); 
							keyInfo = "F5"; 
							keyInfoId = 0x5; 
							break;
		// ...
		default: Console.WriteLine("Not a function key"); break;
	}
	using (var serialPort = new SerialPort())
	{
		serialPort.Open();
		serialPort.WriteLine(keyInfo);
		serialPort.Write(new byte[] { keyInfoId }, 0, 1);
		serialPort.Close();
	}
