    IEnumerable<String[]> lineColumns = lines
        .Select(line => line.Split('^'));
    textBox1.Lines = lineColumns.Select(cols => cols[0]).ToArray();
    textBox2.Lines = lineColumns.Select(cols => cols[1]).ToArray();
    textBox3.Lines = lineColumns.Select(cols => cols[2]).ToArray();
