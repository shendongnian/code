        public void PokerHands7from52()
        {
            for (byte i = 0; i < 52; i++)
                Debug.WriteLine("rank " + i % 13 + "  suite " + i / 13);
    
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int counter = 0;
            for (int i = 51; i >= 6; i--)
            {
                for (int j = i - 1; j >= 5; j--)
                {
                    for (int k = j - 1; k >= 4; k--)
                    {
                        for (int m = k - 1; m >= 3; m--)
                        {
                            for (int n = m - 1; n >= 2; n--)
                            {
                                for (int p = n - 1; p >= 1; p--)
                                {
                                    for (int q = p - 1; q >= 0; q--)
                                    {
                                        // the 7 card are i, j, k, m, n, p, q
                                        counter++;
                                        if (counter % 10000000 == 0)
                                            Debug.WriteLine(counter.ToString("N0") + " " + sw.ElapsedMilliseconds.ToString("N0"));
                                    }
                                } 
                            }
                                        
                        }
                    }
                }
            }
            sw.Stop();
            System.Diagnostics.Debug.WriteLine("counter " + counter.ToString("N0") + "  should be 133,784,560");
            System.Diagnostics.Debug.WriteLine("sw " + sw.ElapsedMilliseconds.ToString("N0"));
        }
    }
