            using (StreamReader sr = new StreamReader(@"C:\Users\as\Desktop\file\1.txt", Encoding.Default))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split('\n');
                string[][] matrix = new string[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                {
                    matrix[i] = lines[i].Split(' ');
                }
                //print column by column
                var rowLength = matrix[0].Length; // assuming every row has the same length
                //for each column
                for (int i = 0; i < rowLength; i++)
                {
                    //print each cell
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        Console.WriteLine(matrix[j][i]);
                    }
                }
            }
