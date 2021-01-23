    var dict = new Dictionary<string, string>();
    using (var diag = new OpenFileDialog()) {
        if (diag.ShowDialog() == DialogResult.OK) {
            using (var sr = new StreamReader(diag.FileName)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    var split = line.Replace(";", "").Split(':');
                    dict.Add(split[0], split[1]);
                }
            }
        }
    }
