    // Example regression problem. Suppose we are trying
    // to model the following equation: f(x, y) = 2x + y
    
    double[][] inputs = // (x, y)
    {
        new double[] { 0,  1 }, // 2*0 + 1 =  1
        new double[] { 4,  3 }, // 2*4 + 3 = 11
        new double[] { 8, -8 }, // 2*8 - 8 =  8
        new double[] { 2,  2 }, // 2*2 + 2 =  6
        new double[] { 6,  1 }, // 2*6 + 1 = 13
        new double[] { 5,  4 }, // 2*5 + 4 = 14
        new double[] { 9,  1 }, // 2*9 + 1 = 19
        new double[] { 1,  6 }, // 2*1 + 6 =  8
    };
    
    double[] outputs = // f(x, y)
    {
            1, 11, 8, 6, 13, 14, 20, 8
    };
    
    // Create Kernel Support Vector Machine with a Polynomial Kernel of 2nd degree
    var machine = new KernelSupportVectorMachine(new Polynomial(2), inputs: 2);
    
    // Create the sequential minimal optimization teacher
    var learn = new SequentialMinimalOptimizationRegression(machine, inputs, outputs);
    
    // Run the learning algorithm
    double error = learn.Run();
    
    // Compute the answer for one particular example
    double fxy = machine.Compute(inputs[0]); // 1.0003849827673186
