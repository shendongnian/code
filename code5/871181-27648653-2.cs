    // Train the sequence classifier using the algorithm
    double logLikelihood = teacher.Run(sequences, labels);
    
    
    // Calculate the probability that the given
    //  sequences originated from the model
    double likelihood, likelihood2;
    
    // Try to classify the 1st sequence (output should be 0)
    int c1 = classifier.Compute(sequences[0], out likelihood);
    
    // Try to classify the 2nd sequence (output should be 1)
    int c2 = classifier.Compute(sequences[1], out likelihood2);
