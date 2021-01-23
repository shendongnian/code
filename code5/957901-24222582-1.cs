       using (System.IO.StreamWriter writer = new System.IO.StreamWriter("NEW.txt"))
            {
                /* This next line is the root of your problem */
                //System.Console.SetOut(writer);
                
                /* Just write directly with `writer` */
                writer.WriteLine("Hello text file");
                writer..WriteLine("I'm writing to you from visual C#");
            }
