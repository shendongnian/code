    void MyFunction(params float[] list)
    {
        // do something
    }
    MyFunction(new float[] { 3.0f, 4.0f }); // valid call
    MyFunction(3.0f, 4.0f); // also valid
    MyFunction(32f); // also valid
    MyFunction(); // also valid, beware! list will be an empty array
    MyFunction(null); // also valid, beware! list will be null
