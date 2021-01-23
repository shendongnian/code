    delegate double UnaryOp(double x);
    double[] array_unary_op(double[] arr, UnaryOp op)
    {
        double[] result = new double[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            result[i] = op(arr[i]);
        }
        return result;
    }
