     using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(@"jsonGonna.txt", true))
            {
                file.WriteLine(json);
            }
