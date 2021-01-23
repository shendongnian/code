    Data process(String input)
    {
        var elements = input.Split(new char[] {':'});
        Data result;
        result.letters = elements[0].Trim();
        result.digits = elements[1].Trim().Replace("-", "");
        return result;
    }
