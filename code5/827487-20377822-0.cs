    var linesArray = File.ReadAllLines("filepath");
    var lines = new List<string>(linesArray);
    var newLines = new List<string>();
    int insertLinesAt = 4;
    int counter = 0;
    
    foreach (var line in lines)
    {
      if(counter == insertLinesAt)
      {
    		newLines.Add("AAAAAAA_VVVV_vVVVV_vvVV9");
    		newLines.Add("AAEEEE_VVVV_vVVVV_vvVV9");
      }
    	newLines.Add(line);
    	counter++;
    }
    
    File.WriteAllLines("newFile.txt", newLines);
