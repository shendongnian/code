    int MobileID = 0;
    System.Console.WriteLine("Enter Mobile ID in Numbers and press enter");
    MobileID = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine("You entered the number:" + MobileID.ToString + ".");
    Console.ReadKey();
    StreamReader reader = File.OpenText("C:\\Robotron\\Execution\\MobileID_Type.txt");
    string line = null;
    while (reader.Peek != -1) {
    	line = reader.ReadLine();
    	string[] fields = line.Split(ControlChars.Tab);
    	if (MobileID == Convert.ToInt32(fields(0))) {
    		Console.WriteLine("Mobile Type is:" + fields(1).ToString);
    		break; // TODO: might not be correct. Was : Exit Do
    	}
    }
    Console.ReadKey();
