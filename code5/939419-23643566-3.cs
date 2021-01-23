    var left = new List<string>();
    var right = new List<string>();
    using (var diag = new OpenFileDialog()) {
        if (diag.ShowDialog() == DialogResult.OK) {
            using (var sr = new StreamReader(diag.FileName)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    var split = line.Replace(";", "").Split(':');
                    if (split[0] != null && split[1] != null) {
                        left.Add(split[0]);
                        right.Add(split[1]);
                    }
                }
            }
        }
    }
