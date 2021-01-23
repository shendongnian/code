    // Ensure we have reproducible results
    Accord.Math.Random.Generator.Seed = 0;
    
    // Get some data to be learned: Here we will download and use Wiconsin's
    // (Diagnostic) Breast Cancer dataset, where the goal is to determine
    // whether the characteristics extracted from a breast cancer exam
    // correspond to a malignant or benign type of cancer. In order to do
    // this using the Accord.NET Framework, all we have to do is:
    var data = new WisconsinDiagnosticBreastCancer();
    // Now, we can import the input features and output labels using
    double[][] input = data.Features; // 569 samples, 30-dimensional features
    int[] output = data.ClassLabels;  // 569 samples, 2 different class labels
    
    // Now, let's say we want to measure the cross-validation performance of
    // a decision tree with a maximum tree height of 5 and where variables
    // are able to join the decision path at most 2 times during evaluation:
    var cv = CrossValidation.Create(
    
        k: 10, // We will be using 10-fold cross validation
    
        learner: (p) => new C45Learning() // here we create the learning algorithm
        {
            Join = 2,
            MaxHeight = 5
        },
    
        // Now we have to specify how the tree performance should be measured:
        loss: (actual, expected, p) => new ZeroOneLoss(expected).Loss(actual),
    
        // This function can be used to perform any special
        // operations before the actual learning is done, but
        // here we will just leave it as simple as it can be:
        fit: (teacher, x, y, w) => teacher.Learn(x, y, w),
    
        // Finally, we have to pass the input and output data
        // that will be used in cross-validation. 
        x: input, y: output
    );
    
    // After the cross-validation object has been created,
    // we can call its .Learn method with the input and 
    // output data that will be partitioned into the folds:
    var result = cv.Learn(input, output);
    
    // We can grab some information about the problem:
    int numberOfSamples = result.NumberOfSamples; // should be 569
    int numberOfInputs = result.NumberOfInputs;   // should be 30
    int numberOfOutputs = result.NumberOfOutputs; // should be 2
    
    double trainingError = result.Training.Mean; // should be 0
    double validationError = result.Validation.Mean; // should be 0.089661654135338359
