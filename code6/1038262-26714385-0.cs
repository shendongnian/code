    public class MaxLinesWriter
    {
        ...
        private StreamWriter writer;
    
        public MaxLinesWriter(string NameFileInput, int MaxLinesInput)
        {
            ...
            writer = new StreamWriter(NameFile + ".txt", true);
        }
    
        public void WriteLine(object StringToWrite)
        {
            if (CounterOfLines < MaxLines)
            {
        //Remove            StreamWriter writer = new StreamWriter(NameFile + ".txt", true);
                writer.WriteLine(StringToWrite);
                CounterOfLines++;
                writer.Close();
             }
             else
             {
                 writer.Close();
                 writer = new StreamWriter(NameFile + ".txt");
               ...
             }
        }
    }
