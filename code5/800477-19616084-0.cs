    var str = File.ReadAllText(@"c:\File1.txt");
                    var arr = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    arr.ToList().ForEach(o =>
                        {
                            if (o.StartsWith("play"))
                            {
                                o.Replace("play", "123");
                            }
                        });
                    var result=string.Join(" ", arr);//result string to 
    File.WriteAllText(@"c:\File1.txt", result);
