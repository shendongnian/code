    public string doSomething(string param1, int status)
    {
        if (IsValidEnum<Status>(status))
        {
            Account.Status = (Status)status;
        }
        ...
    }
    private bool IsValidEnum<T>(int value)
    {
        var validValues = Enum.GetValues(typeof(T));
        var validIntValues = validValues.Cast<int>();
        return validIntValues.Any(v => v == value);
    }
