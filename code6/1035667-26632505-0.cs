    float[, ,] vectors;
    int pos = 0;
    
    vectors = new float[,,]
    {
        {
            { 0, 1, 2}, { 0, 3, 4}
        }
    }
    
    vectors[0,1,0] = 33;
    vectors[0,1,1] = 44;
    vectors[0,1,2] = 55;
