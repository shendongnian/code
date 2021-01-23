        public class MaxLinesWriter
        {
            public int MaxLines;
            public string NameFile;
            private string ConstNameFile;
            public int CounterOfLines;
            private FileStream st;
            private StreamWriter writer;
            DateTime date = new DateTime();
            public MaxLinesWriter(string NameFileInput, int MaxLinesInput)
            {
                MaxLines = MaxLinesInput;
                ConstNameFile = NameFileInput;
                NameFile = ConstNameFile + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + date.Millisecond.ToString();
                CounterOfLines = 0;
                st = new FileStream(NameFile + ".txt", FileMode.CreateNew);
                writer = new StreamWriter(st, Encoding.UTF8, 10240, true);
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
                    CounterOfLines = 1;
                    date = date.AddMilliseconds(1);
                    NameFile = ConstNameFile + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + date.Millisecond.ToString();
                    st = new FileStream(NameFile + ".txt", FileMode.CreateNew);
                    writer = new StreamWriter(st, Encoding.UTF8, 10240, true);
                    writer.WriteLine(StringToWrite);
                }
            }
        }
