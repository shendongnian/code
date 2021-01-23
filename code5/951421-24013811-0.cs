    public static Matrix4 operator *(Transform u, Matrix4 v) {
        return Mult(u, v);
    }
    public static Matrix4 operator *(Matrix4 u, Transform v) {
        return Mult(u, v);
    }
    // The actual implementation goes here
    private static Matrix4 Mult(Matrix4 u, Transform v) {
        return u* v.Result;
    }
