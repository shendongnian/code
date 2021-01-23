    public static List<DataValue> ParseDataFile(string filePath) {
        var reader = new StreamReader(filePath);
        var values = new List<DataValue>();
        var variableHeader = FindNextVariable(reader);
        while(!string.IsNullOrEmpty(variableHeader)) {
            DataValue v;
            switch(FindVariableType(variableHeader)) {
                case Scalar:
                    v = new ScalarValue();
                case OneDimensionalArray:
                    v = new Array1DValue();
                // etc
            }
            v.ReadValue(variableHeader, reader);
            values.Add(v);
            variableHeader = FindNextVariable(reader);
        } 
        return values;
    }
