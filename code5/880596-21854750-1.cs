    var t = new List<string>();
            t.Add("aaa");
            t.Add("bbb");
            t.Add("ccc");
            // ...
            using (StreamWriter w = File.AppendText(path))
            {
                for (int i = 1; i <= 10; i++)
                {
                    string key = "t"+i;
                    
                    if (key == "t1")
                    {
                    w.WriteLine(t[1]);
                    }
                    if (key == "t2")
                    {
                        w.WriteLine(t[2]);
                    }
   
                }
            }
