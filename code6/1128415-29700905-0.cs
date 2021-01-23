    // Create some sample input data instances. This is the same
    // data used in the Gutierrez-Osuna's example available at:
    // http://research.cs.tamu.edu/prism/lectures/pr/pr_l10.pdf
    
    double[][] inputs = 
    {
        // Class 0
        new double[] {  4,  1 }, 
        new double[] {  2,  4 },
        new double[] {  2,  3 },
        new double[] {  3,  6 },
        new double[] {  4,  4 },
    
        // Class 1
        new double[] {  9, 10 },
        new double[] {  6,  8 },
        new double[] {  9,  5 },
        new double[] {  8,  7 },
        new double[] { 10,  8 }
    };
    
    int[] output = 
    {
        0, 0, 0, 0, 0, // The first five are from class 0
        1, 1, 1, 1, 1  // The last five are from class 1
    };
    
    // Then, we will create a LDA for the given instances.
    var lda = new LinearDiscriminantAnalysis(inputs, output);
    
    lda.Compute(); // Compute the analysis
    
    
    // Now we can project the data into LDA space:
    double[][] projection = lda.Transform(inputs);
