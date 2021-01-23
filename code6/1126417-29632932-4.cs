    public enum VariableType {
        Scalar,
        OneDimensionalValue,
        TwoDimensionalValue,
        ThreeDimensionalValue,
        Other
    }
    public static VariableType FindVariableType(string header) {
        var fields = string.Split('/', header);
        // take the third item, parse it to determine type
    }
