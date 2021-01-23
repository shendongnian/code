	using (TextReader textReader = new StreamReader(fileName)){
		string onlyLine = textReader.ReadLine();
		if (onlyLine == null) 
			throw new /*UnexpectedData*/Exception("file is empty!");
		string[] splitPixel = onlyLine.Split(' ');
		for (int i=0; i<splitPixel.Length; i++) {
			string[] splitted = splitPixel[i].Split(',');
			int tempR = int.Parse(splitted[0]);
			int tempG = int.Parse(splitted[1]);
			int tempB = int.Parse(splitted[2]);
			Color pixel = Color.FromArgb(tempR,tempG,tempB);
			bmp.SetPixel(x, y, pixel);
		}	
	}
