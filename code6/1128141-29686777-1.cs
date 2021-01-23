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
    
    // Create the sequential minimal optimization teacher
    var learn = new SequentialMinimalOptimizationRegression<Polynomial>()
    {
        Kernel = new Polynomial(degree: 2)
    }
    
    // Use the teacher to learn a new machine
    var svm = teacher.Learn(inputs, outputs);
    
    // Compute the answer for one particular example
    double fxy = machine.Transform(inputs[0]); // 1.0003849827673186
    // Compute the answer for all examples 
    double[] fxys = machine.Transform(inputs); 
