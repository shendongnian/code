    int red = 10;
	int green = 5;
	int blue = 5;
	int orange = 3;
	int MarbleCnt = red + green + blue + orange;
	double probRed = (double)red / MarbleCnt;
	double probGreen = (double)green / MarbleCnt;
	double probBlue = (double)blue / MarbleCnt;
	double probOrange = (double)orange / MarbleCnt;
	
	Console.WriteLine("Red: " + probRed);		
	Console.WriteLine("Green: " + probGreen);		
	Console.WriteLine("Blue: " + probBlue);		
	Console.WriteLine("Orange: " + probOrange);
