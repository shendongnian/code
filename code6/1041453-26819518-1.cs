    static void Main(string[] args) {
        string innerNum;
        string outerNum = "";
    	double sum = 0;
    	int count = 0;
        if (File.Exists("averages.txt")) {
            try {
                StreamReader inFile = new StreamReader("averages.txt");
                while ((innerNum = inFile.ReadLine()) != null) {
    				try {
    					outerNum += innerNum + "\n";
    					sum += double.Parse(innerNum);
    					count++;
    				} catch(Exception e) {}
                }
                Console.WriteLine(outerNum);
            } catch (System.IO.IOException e) {
                Console.WriteLine("IO Exception: " + e.Message);
            }
        }  else {
    		Console.WriteLine("The File Does Not Exist.");
        }
    	Console.WriteLine("Average is : " + String.Format("{0:N2}",sum/(double)count));
    
        Console.Write("Press Enter to Exit.");
        Console.ReadKey();
    }
