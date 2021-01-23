    static object obj = new object();
                static void WriteInGrid(string message)
                { 
                    lock(obj)
                    {
                         Yourdelegate (message)
                    }
                }
