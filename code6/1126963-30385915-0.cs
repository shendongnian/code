    double[][] inputs = new double[DataFiles.Count][];
    int[] outputs = new int[DataFiles.Count];
    //fill the inputs and outputs with your data
    double c = SequentialMinimalOptimization.EstimateComplexity(inputs);
    // Creates the SVM for input variables
    SupportVectorMachine svm = new SupportVectorMachine(inputs:Count);
    // Creates a new instance of the sparse logistic learning algorithm
    var smo = new ProbabilisticDualCoordinateDescent(svm, inputs, outputs)
    {
    // Set learning parameters
    Complexity = c,
    Tolerance = 1e-5,
    };
    try
    {
    double error = smo.Run();
    }
    catch (ConvergenceException)
    {
    }
    // Show feature weight importance
    double[] weights = svm.Weights;
