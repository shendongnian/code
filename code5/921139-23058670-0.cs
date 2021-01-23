    var myEnums = new Dictionary<string, int>();
    
    public void ReadIt()
    {
        // Open your textfile into a streamreader
        using (System.IO.StreamReader sr = new System.IO.StreamReader("text_path_here.txt"))
        {
            while (!sr.EndOfStream) // Keep reading until we get to the end
            {
                string splitMe = sr.ReadLine(); //suppose key and value are stored like "CAREA:10"
                string[] keyValuePair = splitMe.Split(new char[] { ':' }); //Split at the colons
    
                myEnums.Add(keyValuePair[0], (int)keyValuePair[1]);
            }
        }
    }
