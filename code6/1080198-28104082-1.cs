            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
                {
                    while (true)
                    {
                        if (!fc.SecondString.Equals(AnotherPartyLibrary.firstString))
                        {
                            fc.SecondString = AnotherPartyLibrary.firstString;
                        }
                        Thread.Sleep(1000);
                    }
                };
            bw.RunWorkerAsync();
