                List<MyObject> objects = new List<MyObject>();
                using (StreamReader sr = new StreamReader(aPath))
                {
                    MyObject curObj;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.IndexOf(':') >= 0) // or whatever identify the beginning of a new object
                        {
                            curObj = new MyObject(line);
                            objects.Add(curObj);
                        }
                        else
                            curObj.AddAttribute(line);
                    }
                }
