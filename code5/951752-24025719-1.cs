    public StringBuilder AppendLine() {
        return Append(Environment.NewLine);
    }
    public StringBuilder AppendLine(string value) {
        Append(value);
        return Append(Environment.NewLine);
    }
