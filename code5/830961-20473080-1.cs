     bool flag;
    
                System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
                list.Add(1);
                list.Add(2);
                list.Add(3);
                System.Collections.Generic.List<int>.Enumerator enumerator = list.GetEnumerator();
                try
                {
                    while (flag)
                    {
                        int i1 = enumerator.get_Current();
                        System.Console.WriteLine(i1);
                        flag = enumerator.MoveNext();
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }
                enumerator = list.GetEnumerator();
                try
                {
                    while (flag)
                    {
                        int i2 = enumerator.get_Current();
                        System.Console.WriteLine(i2);
                        flag = enumerator.MoveNext();
                    }
                }
                finally
                {
                    enumerator.Dispose();
                }
