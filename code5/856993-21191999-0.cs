    string[] lines = {"15  EMP_L_NAME HAPPENS 5,1 TIMES.", "40  SUP HAPPENS 12 TIMES. "};
    var allValues = lines.Select(line =>
                {
                    double temp;
                    var words = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var value = words[Array.IndexOf(words,"TIMES.") - 1];
                    if (double.TryParse(value, out temp)) return temp;
                    else return 0;
                }).ToList();
                foreach (var value in allValues)
                {
                    Console.WriteLine(value);
                }  
    // Output:
    //   5,1
    //   12
