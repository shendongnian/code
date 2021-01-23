            static void Main(string[] args)
            {
              String myfile= System.IO.File.ReadAllText("myfile.dat");
              String[] strWord = myfile.Split('|');
              using(System.IO.StreamWriter writer = new System.IO.StreamWriter("myfile.txt", true))
              {              
              foreach (string str in strWord)
                  writer.WriteLine(str.Trim());
              }
            }
