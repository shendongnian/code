    using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\Settings.txt", true))
    { 
        string line;
        int currentLineNumber = 0;
        while ((line = sr.ReadLine()) != null)
        {
            switch (++currentLineNumber)
            {
                case 1: first = line; break;
                case 2: second = line; break;
                case 3: third = line; break;
                case 4: fourth = line; break;
            }
        }
    }
