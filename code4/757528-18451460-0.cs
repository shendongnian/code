    // Make the extraction its own method
    private static IEnumerable<string> ExtractFirstTwoColumns(string fileName) {
        return System.IO.File.ReadLines(fileName).Select(
             line => {
                  string[] words = line.Split(delimiterChars);
                  return words[0] + words[1];
             }
        );
    }
    protected void Page_Load(object sender, EventArgs e)
        // Use extraction to do both comparisons and to write
        var extracted1 = ExtractFirstTwoColumns(@"C:\Test\Test1.txt").ToList();
        var extracted2 = ExtractFirstTwoColumns(@"C:\Test\Test2.txt").ToList();
        // Write the content to the response
        foreach (var s in extracted1) {
            Response.Write(s);
        }
        foreach (var s in extracted2) {
            Response.Write(s);
        }
        // Do the comparison
        if (extracted1.SequenceEqual(extracted2)) {
            Console.Error.WriteLine("First two columns are different.");
        }
    }
