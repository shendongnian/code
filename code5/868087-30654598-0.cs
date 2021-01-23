    public void Send(string body, [FromUri] List<string> phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(body) || phoneNumber == null)
        {
            // return error message
        }
        if (phoneNumber.Count == 1 && phoneNumber[0].IndexOf(',') > -1)
        {
            var phonenumbers = phoneNumber[0]
            .Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
            // execute method#1 and pass array of phonenumbers
        }
        else
        {
            // execute method#2 and pass list of phonenumbers
        }
    }
