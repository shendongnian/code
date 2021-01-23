    public static Matrix operator *(Matrix x, Matrix y)
    {
        return Matrix.Multiply(x, y);
    }
    public static Matrix operator +(OffsetsType offsets)
    {
        this.Add(offsets);
    }
