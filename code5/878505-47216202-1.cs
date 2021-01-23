    // I decided to use this solution
    // this section is to clear MyFile.txt
         using(StreamWriter sw = new StreamWriter(@"MyPath\MyFile.txt", false))
         {
           foreach(string line in listofnames)
           {
              sw.Write("");	// change WriteLine with Write
           }
            sw.Close();
          }
        // and this section is to copy file names to MyFile.txt
        	using(StreamWriter file = new StreamWriter(@"MyPath\MyFile.txt", true))
        	{
            foreach(string line in listofnames)
            {
            	file.WriteLine(line);
            }
          }
