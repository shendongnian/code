    List<string> lines = new List<string>();
    bool skipping = true;
    using (var sr = new StreamReader("TextFile1.txt")) {
        string line;
        while ((line = sr.ReadLine()) != null) {
            line = line.TrimEnd();
            if (skipping) {
                if (line == "Upper1=0") {
                    skipping = false;
                }
            }
            if (!skipping) {
                lines.Add(line);
                if (line == "[HRData]") {
                    break;
                }
            }
        }
    }
