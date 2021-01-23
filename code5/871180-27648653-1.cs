    // Create one base Normal distribution to be replicated accross the states
    var initialDensity = new MultivariateNormalDistribution(4); // we have 4 features
    
    // Creates a sequence classifier containing 2 hidden Markov Models with 2 states
    // and an underlying multivariate mixture of Normal distributions as density.
    var classifier = new HiddenMarkovClassifier<MultivariateNormalDistribution>(
        classes: 2, topology: new Forward(2), initial: initialDensity);
    
    // Configure the learning algorithms to train the sequence classifier
    var teacher = new HiddenMarkovClassifierLearning<MultivariateNormalDistribution>(
        classifier,
    
        // Train each model until the log-likelihood changes less than 0.0001
        modelIndex => new BaumWelchLearning<MultivariateNormalDistribution>(
            classifier.Models[modelIndex])
        {
            Tolerance = 0.0001,
            Iterations = 0,
            FittingOptions = new NormalOptions()
            {
                Diagonal = true,      // only diagonal covariance matrices
                Regularization = 1e-5 // avoid non-positive definite errors
            }
            // PS: Setting diagonal = true means the features will be
            // assumed independent of each other. This can also be
            // achieved by using an Independent<NormalDistribution>
            // instead of a diagonal multivariate Normal distribution
        }
    );
    
