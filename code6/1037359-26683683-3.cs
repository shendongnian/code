    private string _timeRemainingString = "                Time Remaining:  ";
    private void UpdateTime(int i)
    {
        //Move to the first column that would have had numbers.
        Console.CursorLeft = _timeRemainingString.Length;
    
        //Move to the 4th row
        Console.CursorTop = 3;
        
        //overwrite just the number portion.
        Console.Write(i.ToString() + "          ");
    }
