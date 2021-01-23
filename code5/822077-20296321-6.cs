    const char splitter = '\t';   // use a char that will not appear in your string
    string input = "ABCDABCABCDABCABCDABCABCDABCD";
    string oldString = "BC";
    string[] newStrings = { "AA", "BB", "CC", "DD", "EE" };
    
    // In input, replace oldString with tabs, so that we can do String.Split later
    var inputTabbed = input.Replace(oldString, splitter.ToString());
    // ABCDABCABCDABCABCDABCABCDABCD --> A\tDA\tA\tDA\tA\tDA\tA\tDA\tD
    var inputs = inputTabbed.Split(splitter);
    /* inputs (the template) now contains:
    [0] "A" 
    [1] "DA"
    [2] "A" 
    [3] "DA"
    [4] "A" 
    [5] "DA"
    [6] "A" 
    [7] "DA"
    [8] "D" 
    */
    // In parallel, build the output using the template (inputs)
    // and the replacement strings (newStrings)
    var outputs = new List<string>();
    Parallel.ForEach(newStrings, iteration =>
        {
            var output = string.Join(iteration, inputs);
            // only lock the list operation
            lock (outputs) { outputs.Add(output); }
        });
    foreach (var output in outputs)
        Console.WriteLine(output);
