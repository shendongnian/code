    // Let's say we have the following data to be classified
    // into three possible classes. Those are the samples:
    // 
    double[][] inputs =
    {
        //               input         output
        new double[] { 0, 1, 1, 0 }, //  0 
        new double[] { 0, 1, 0, 0 }, //  0
        new double[] { 0, 0, 1, 0 }, //  0
        new double[] { 0, 1, 1, 0 }, //  0
        new double[] { 0, 1, 0, 0 }, //  0
        new double[] { 1, 0, 0, 0 }, //  1
        new double[] { 1, 0, 0, 0 }, //  1
        new double[] { 1, 0, 0, 1 }, //  1
        new double[] { 0, 0, 0, 1 }, //  1
        new double[] { 0, 0, 0, 1 }, //  1
        new double[] { 1, 1, 1, 1 }, //  2
        new double[] { 1, 0, 1, 1 }, //  2
        new double[] { 1, 1, 0, 1 }, //  2
        new double[] { 0, 1, 1, 1 }, //  2
        new double[] { 1, 1, 1, 1 }, //  2
    };
    
    int[] outputs = // those are the class labels
    {
        0, 0, 0, 0, 0,
        1, 1, 1, 1, 1,
        2, 2, 2, 2, 2,
    };
    
    // Create a one-vs-one multi-class SVM learning algorithm 
    var teacher = new MulticlassSupportVectorLearning<Linear>()
    {
        // using LIBLINEAR's L2-loss SVC dual for each SVM
        Learner = (p) => new LinearDualCoordinateDescent()
        {
            Loss = Loss.L2
        }
    };
        
    // Learn a machine
    var machine = teacher.Learn(inputs, outputs);
    
    // Obtain class predictions for each sample
    int[] predicted = machine.Decide(inputs);
    
    // Compute classification accuracy
    double acc = new GeneralConfusionMatrix(expected: outputs, predicted: predicted).Accuracy;
