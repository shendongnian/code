    List<string> linesBefore = new List<string>();
    List<string> lines = new List<string>();
    List<string> linesAfter = new List<string>();
    // 0 = before Upper1=0, 
    // 1 = between Upper1=0 and [HRData]
    // 2 = after [HRData]
    int state = 0;
    using (var sr = new StreamReader("TextFile1.txt")) {
        string line;
        while ((line = sr.ReadLine()) != null) {
            line = line.TrimEnd();
            if (state == 0) {
                if (line == "Upper1=0") {
                    state = 1;
                    lines.Add(line);
                } else {
                    linesBefore.Add(line);
                }
            } else if (state == 1) {
                lines.Add(line);
                if (line == "[HRData]") {
                    state = 2;
                }
            } else {
                // state == 2
                linesAfter.Add(line);
            }
        }
    }
