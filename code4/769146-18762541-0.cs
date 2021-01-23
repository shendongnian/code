    public void CreateForm(string passengerType, int passengerCount)
    {
        /* List to hold id values */
        List<string> ids = new List<string>();
        for (int i = 1; i <= passengerCount; i++)
        {
            Response.Write("<table id=NameBirthTable" + passengerType + i + ">");
            Response.Write("<tr>"); 
            //   ...
            Response.Write("<td colspan=2><input id=MiddleName" + passengerType +i+ "type=text /></td>");
            //    ...
            /* Add newly created input id to list */
            ids.Add("MiddleName" + passengerType +i);
        }
        /* Output the ids collection to hidden field value */
        Response.Write("<input type='hidden' id='hiddenElement' value='" + string.Join(",", ids.ToArray()) + "'></input>");
    }
