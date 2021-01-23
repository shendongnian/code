               public void XYZFile()
               {
                    List<XYZ> xyzList = new List<XYZ>();
                    string[] xyzFileContant = File.ReadAllLines(Server.MapPath("~/XYZ.txt"));
                    //int lineCount = xyzFileContant.Length;
                    foreach (string cont in xyzFileContant)
                    {
                        if (!String.IsNullOrWhiteSpace(cont))
                        {
                            string[] contSplit = cont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            xyzList.Add(new XYZ
                                                {
                                                    X = Convert.ToInt32(contSplit[0]),
                                                    Y = Convert.ToInt32(contSplit[1]),
                                                    Z = Convert.ToInt32(contSplit[2])
                                                }
                                );
                        }
                    }
                }
   
        public class XYZ
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }
