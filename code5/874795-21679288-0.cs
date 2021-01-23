            const int countX = 100;
            const int countY = 100;
            const int countLayer = 5;
            TiledMap tm = new TiledMap(countLayer, countX, countY);
            const int testRuns = 10000;
            Console.WriteLine("Run 1, start");
            DateTime start1 = DateTime.Now;
            for (int test = 0; test < testRuns; test++)
            {
                for (int i = 0; i < countLayer; i++)
                {
                    for (int j = 0; j < countX; j++)
                    {
                        for (int k = 0; k < countY; k++)
                        {
                            int data = tm.GetTile(i, j, k);
                            data++;
                        }
                    }
                }
            }
            DateTime end1 = DateTime.Now;
            Console.WriteLine(String.Format("Run 1, time: {0}", end1-start1));
            Console.WriteLine("Run 2, start");
            DateTime start2 = DateTime.Now;
            for (int test = 0; test < testRuns; test++)
            {
                for (int i = 0; i < countLayer; i++)
                {
                    for (int j = 0; j < countX; j++)
                    {
                        for (int k = 0; k < countY; k++)
                        {
                            int data = tm.DirectArray[i, k*countX + j];
                            data++;
                        }
                    }
                }
            }
            DateTime end2 = DateTime.Now;
            Console.WriteLine(String.Format("Run 1, time: {0}", end2 - start2));
            Console.ReadLine();
