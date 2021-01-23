    private static void TemplatingImp(string input, string replaceWhat, IEnumerable<string> replaceIterations)
    {
        const char splitter = '\t';   // use a char that will not appear in your string
        var inputTabbed = input.Replace(replaceWhat, splitter.ToString());
        var inputs = inputTabbed.Split(splitter);
        // In parallel, build the output using the split parts (inputs)
        // and the replacement strings (newStrings)
        //var outputs = new List<string>();
        Parallel.ForEach(replaceIterations, iteration =>
        {
            var output = string.Join(iteration, inputs);
        });
    }
