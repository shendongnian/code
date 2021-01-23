    public static Union2<Matrix, float> operator *(Vector x, Vector y)
    {
        (...)
        return multiplicationResultMatrix != null 
            ? new Union2<Matrix, float>.Case1(multiplicationResultMatrix)
            : new Union2<Matrix, float>.Case2(multiplicationResultFloat);
    }
