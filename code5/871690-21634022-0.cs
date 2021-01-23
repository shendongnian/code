    var value = 2.524;
    var result = RoundUpValue(value, 2); // Answer is 2.53
    public double RoundUpValue(double value, int decimalpoint)
    {
        var result = Math.Round(value, decimalpoint);
        if (result < value)
        {
            result += Math.Pow(10, -decimalpoint);
        }
        return result;
    }
