        static void TestMe ()
        {
            List<object> TicketList = new List<object>();
            for (int index = 0; index < 109; index++)
                TicketList.Add(new object());
            var rand = new Random();
            int nColumns = 100;
            int NumOfRows = (TicketList.Count + (nColumns - 1)) / nColumns;
            object[,] numbers;
            int t;
            numbers = new object[nColumns, NumOfRows];
            for (int j = 0; j < NumOfRows; j++)
            {
                Console.WriteLine("OuterLoop");
                for (int i = 0; i < nColumns; i++)
                {
                    if (TicketList.Count > 0)
                    {
                        t = rand.Next(0, TicketList.Count - 1);
                        numbers[i, j] = TicketList[t];
                        TicketList.RemoveAt(t);
                    }
                }
            }
        }
