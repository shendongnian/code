    private static int LineCompare(string filepath1, string filepath2)
            {
                var result = 0;
    
                var list = File.ReadLines(filepath1).ToArray();
                var list2 = File.ReadLines(filepath2).ToArray();
    
                for (var i = 0; i < list.Length; i++)
                {
                    if (list[i].Equals(list2[i]))
                        result++;
                }
    
                return result;
            }
