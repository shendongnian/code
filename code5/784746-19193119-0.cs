    public bool validateVoter(String cisNo)
    {
        bool found = false;
        try
        {
            string[] ID = System.IO.File.ReadAllLines(@"C:\Users\Hlogoyatau\Pictures\votersRoll.txt");
            for (int i = 0; i < ID.Length; i++)
            {
                string line = ID[i];
                //compares it against text file contents
                if (cisNo == line)
                {
                    //Shift remaining lines up, overwriting current line
                    for (int j = i; j < ID.Length - 1; j++)
                    {
                         ID[j] = ID[j+1];
                    }
                    //Set last line to empty string
                    ID[ID.Length - 1] = "";
                    //Write file back to disk
                    System.IO.File.WriteAllLines(@"C:\Users\Hlogoyatau\Pictures\votersRoll.txt", ID);
                    found = true;
                    //Exit loop after something is found
                    break;
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.ToString());
        }
        return found;
    }
