                string path = @"C:\mytesttext.txt";
                string text2write = "Hello World!";
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
                writer.Write(text2write);
                writer.Close();
            
