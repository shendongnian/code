    public System.Drawing.Color colordetector(string name)
    {
        
        if (name.Contains("blue") == true) { return System.Drawing.Color.Blue; }
        if (name.Contains("green") == true) { return System.Drawing.Color.Green;    }
        if (name.Contains("red") == true) { return System.Drawing.Color.Red; }
         return System.Drawing.Color.Black; // <= Default to send Black if all conditions failled
    }//method colordetector
