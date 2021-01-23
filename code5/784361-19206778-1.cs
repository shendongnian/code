    string[] lines = File.ReadAllLines(ofd.FileName).Skip(8)
                     .TakeWhile(l => !l.Contains("Total Records")).ToArray();
    textBox1.Lines = lines;
    int[] vale = new int[3];
    int[] pos = new int[3] { 0, 6, 18 };
    int[] len = new int[3] { 6, 12, 28 };
    foreach (string line in textBox1.Lines)
    {
        val[j] = line.Substring(pos[j], len[j]).Trim();
    }
