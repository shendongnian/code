    public void CreateForm(string passengerType, int passengerCount)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= passengerCount; i++)
        {
            sb.AppendLine("<table id='NameBirthTable" + passengerType + i + "'>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<td colspan='2'><input id='MiddleName" + passengerType + i + "' type='text' /></td>");
        }
        Response.Write(sb.ToString());
    }
