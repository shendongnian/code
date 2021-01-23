    static void Main(string[] args)
    {
        int counter = 0;
        int linecounter = 1;
        string line;
        //hashtable to store the key value pairs from the text file
        Hashtable myHT = new Hashtable();
        // Read the file and display it line by line.
        System.IO.StreamReader file =
        new System.IO.StreamReader("c:\\sample.txt");
        while ((line = file.ReadLine()) != null)
        { 
            ....
            // Continue to add values to the hashtable until you reach the 8 row boundary
            myHT.Add(values[0], values[1]);
            if (linecounter == 8)
            {
                ..... insert ...
                 // reset the linecounter and empty the hashtable here for the next row to insert
                linecounter = 0;
                myHT.Clear();
            }
            linecounter++;
            counter++;
        }
