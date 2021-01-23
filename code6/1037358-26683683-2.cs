    private void UpdateTime(int i)
    {
        //Move to the first column.
        Console.CursorLeft = 0;
    
        //Move to the 4th row
        Console.CursorTop = 3;
        
        //Write your text.                                                  Extra spaces to overwrite old numbers
        Console.Write("                Time Remaining:  " + i.ToString() + "          ");
    }
