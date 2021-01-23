    public static char ToChar(int value) {
        if (value < 0 || value > Char.MaxValue) throw new OverflowException(Environment.GetResourceString("Overflow_Char"));
        Contract.EndContractBlock();
        return (char)value;
    }
