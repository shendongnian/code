     using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                foreach (string item in tempListBox)
                {
                    sw.WriteLine(item);
                }
            }
