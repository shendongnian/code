    string line;
    int counter = 0;
    Boolean isFirstLine = true;
    try
    {
        StreamReader sr = new StreamReader("C:\\Files\\gamenam.txt");
        StreamWriter sw = new StreamWriter("C:\\Files\\gamenam_1.txt");
 
        var lines = new List<string>(); //Here goes the temp lines
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Substring(0, 2) == "01")
            {
                if (!isFirstLine)
                {
                    sw.WriteLine(counter.ToString()); //write the number before the lines
                    foreach(var l in lines)
                        sw.WriteLine(l);  //actually write the lines
                    counter = 0;
                    lines.Clear(); //clear the list for next round
                }
            }
    
            if (line.Substring(0, 2) == "05")
            {
                counter++;
            }
    
            lines.add(line); //instead of writing, just adds the line to the temp list
    
            if (sr.Peek() < 0)
            {
                sw.WriteLine(counter.ToString()); //writes everything left
                foreach(var l in lines)
                    sw.WriteLine(l);
            }
    
            isFirstLine = false;
        }
    
        sr.Close();
        sw.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Exception finally block.");
    }
