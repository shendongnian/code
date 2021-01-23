    public override string ToString()
    {
        return string.Format("{0}{1}{2}{3}",
            (IsNegative) ? "-" : "",
            string.Join("", wholeDigits),
            (IsWhole) ? "" : ".",
            (IsWhole) ? "" : string.Join("", decimalDigits));
    }
