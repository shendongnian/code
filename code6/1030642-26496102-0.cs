    @try
    {
        foreach(var row in rowsTestTable)
        {
            <p>@if(!String.IsNullOrEmpty(row.DateValue.ToString())){@Html.Raw(DateTime.Parse(row.DateValue.ToString()))}</p>
        }
    }
    catch (Exception ex)
    {
        <p>@ex.Message</p>
    }
