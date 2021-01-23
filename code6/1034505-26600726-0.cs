    static void Main(string[] args)
        {
            string[][,][] test = { new string[,][]{{
                                                       new string[]{"test1","test2","test3"},
                                                       new string[]{"test4","test5","test6"}
                                                   },
                                                   {
                                                       new string[]{"test7","test8","test9"},
                                                       new string[]{"test10","test11","test12"}
                                                   }},
                                   new string[,][]{{
                                                       new string[]{"test13","test14","test15"},
                                                       new string[]{"test16","test17","test18"}
                                                   },
                                                   {
                                                       new string[]{"test19","test20","test21"},
                                                       new string[]{"test22","test23","test24"}
                                                   }}
                                 };
            for (int a = 0; a < test.Count(); a++)
            {
                foreach(string[] am in test[a])
                {
                    for (int ama = 0; ama < am.Count(); ama++)
                    {
                        Console.WriteLine("{0}", am[ama].ToString()); //Reference to the inside loop
                    }
                }
            }
            Console.ReadKey();
        }
