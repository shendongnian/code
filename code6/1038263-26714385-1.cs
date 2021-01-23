    public class MaxLinesWriter
    {
        private int n = 0;
        public int MaxLines;
        public string NameFile;
        private string ConstNameFile;
        public int CounterOfLines;
        private StreamWriter writer;
        DateTime date = new DateTime();
        public MaxLinesWriter(string NameFileInput, int MaxLinesInput)
        {
            MaxLines = MaxLinesInput;
            ConstNameFile = NameFileInput;
            NameFile = ConstNameFile + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + date.Millisecond.ToString();
            CounterOfLines = 0;
            writer = new StreamWriter(NameFile + ".txt", true);
        }
        public void WriteLine(object StringToWrite)
        {
            if (CounterOfLines < MaxLines)
            {
                writer.WriteLine(StringToWrite);
                CounterOfLines++;
                
            }
            else
            {
                writer.Close();
                CounterOfLines = 1;
                date = date.AddMilliseconds(1);
                NameFile = ConstNameFile + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + date.Millisecond.ToString();
                writer = new StreamWriter(NameFile + ".txt");
                writer.WriteLine(StringToWrite);
            }
        }
	}
