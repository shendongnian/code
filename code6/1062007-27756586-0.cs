    // Create a simple binary AND
    // classification problem:
    
    double[][] problem =
    {
        //             a    b    a + b
        new double[] { 0,   0,     0    },
        new double[] { 0,   1,     0    },
        new double[] { 1,   0,     0    },
        new double[] { 1,   1,     1    },
    };
    
    // Get the two first columns as the problem
    // inputs and the last column as the output
                
    // input columns
    double[][] inputs = problem.GetColumns(0, 1);
    
    // output column
    int[] outputs = problem.GetColumn(2).ToInt32();
    // However, SVMs expect the output value to be
    // either -1 or +1. As such, we have to convert
    // it so the vector contains { -1, -1, -1, +1 }:
    //
    outputs = outputs.Apply(x => x == 0 ? -1 : 1);
    
