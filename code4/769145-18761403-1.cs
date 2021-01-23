    public void CreateForm(string passengerType, int passengerCount)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<table id='NameBirthTable" + passengerType  + "'>");
        for (int i = 1; i <= passengerCount; i++)
        {
            sb.AppendLine("<tr>");
            sb.AppendLine("<td colspan='2'><input id='MiddleName" + passengerType + i + "' type='text' /></td>");
        }
        sb.AppendLine("</table>");
        Response.Write(sb.ToString());
    }
