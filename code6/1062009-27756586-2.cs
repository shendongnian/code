    // Suppose we are going to read a sparse sample file containing
    //  samples which have an actual dimension of 4. Since the samples
    //  are in a sparse format, each entry in the file will probably
    //  have a much smaller number of elements.
    // 
    int sampleSize = 4;
    
    // Create a new Sparse Sample Reader to read any given file,
    //  passing the correct dense sample size in the constructor
    // 
    SparseReader reader = new SparseReader(file, Encoding.Default, sampleSize);
    
    // Declare a vector to obtain the label
    //  of each of the samples in the file
    // 
    int[] labels = null;
    
    // Declare a vector to obtain the description (or comments)
    //  about each of the samples in the file, if present.
    // 
    string[] descriptions = null;
    
    // Read the sparse samples and store them in a dense vector array
    double[][] samples = reader.ReadToEnd(out labels, out descriptions);
