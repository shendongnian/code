    string[] lines = File.ReadAllLines(@"C:\Robotron\Execution\MobileID_Type.txt");
    
    foreach (var line in lines)
    {
        string[] columns = line.Split('\t');
        if(Convert.ToInt32(columns[0]) == MobileId)
        {
             return columns[1];
        }
    }
