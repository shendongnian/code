            using (var strReader = new System.IO.StreamReader())
            {
                while (strReader.Peek() > -1)
                {
                    var line = strReader.ReadLine();
                    // Do Something
                }
                strReader.Close();
            }
