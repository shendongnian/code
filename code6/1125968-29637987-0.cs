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
        // Create a new multi-class linear support vector machine for 3 classes
        var machine = new MulticlassSupportVectorMachine(inputs: 4, classes: 3);
        // Create a one-vs-one learning algorithm using LIBLINEAR's L2-loss SVC dual
        var teacher = new MulticlassSupportVectorLearning(machine, inputs, outputs)
        {
            Algorithm = (svm, classInputs, classOutputs, i, j) =>
                new LinearDualCoordinateDescent(svm, classInputs, classOutputs)
                {
                    Loss = Loss.L2
                }
        };
        // Teach the machine
        double error = teacher.Run(); // should be 0.
