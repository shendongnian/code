    string[] first = System.IO.File.ReadAllLines("path of first txt file");
    string[] second = System.IO.File.ReadAllLines("path of second txt file");
    
    var sb = new StringBuilder();
    
    
    var k = 0;
            var m = 0;
            for (int i = m; i < second.Length; i++)
            {
                m = i + 1;
                for (int j = k; j < first.Length; j++)
                {
                    k = j + 1;
                    if (j != 0 && j % 4 == 0)
                    {
                        sb.Append(second[i] + "\n");
                        break;
                    }
                    else
                    {
                        sb.Append(first[j] + "\n");
                        continue;
                    }
                }
            }
    
    
    // create new txt file
    var file = new System.IO.StreamWriter("path of third txt file");
    file.WriteLine(sb.ToString());
