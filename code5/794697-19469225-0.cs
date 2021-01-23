    using (System.IO.StreamReader sr = new System.IO.StreamReader("YourFile.txt"))
    {
	  String line = sr.ReadLine();
	  Console.WriteLine(line);
    }
