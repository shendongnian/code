            const string log = @"logfile path";
            public void Log(string _text)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(_path, true))
                    {
                        tw.WriteLine("[" + DateTime.Now + "] : " +  _text);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
