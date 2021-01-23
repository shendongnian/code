    private string FixIt(string foo)
    {
        var newFoo = "\\" + string.Join("\\",
            foo.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(s => s[0],
                    (c, g) =>
                    {
                        var cnt = 0;
                        return g.Select(x => cnt++ == 0 
                            ? x 
                            : x[0] + cnt.ToString() + x.Substring(1));
                    })
                .SelectMany(g => g));
        return newFoo;
    }
    Input:  \vToyota\cBlue\cRed\cWhite\s200mph\oAndrew\oJohn
    Output: \vToyota\cBlue\c2Red\c3White\s200mph\oAndrew\o2John
