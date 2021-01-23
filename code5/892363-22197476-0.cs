    foreach (DataRow drow in dsXml.Tables[0].Rows)
    {
        if (!hTable.Contains(drow))
        {
            hTable.Contains(drow);
            hTable.Add(drow);
        }
        else
        {
            duplicateList.Add(drow);
        }
    }
    script.Append("alert('Error - There are some Duplicate entries.'); ");
    ErrorOcc = true;
    if (ErrorOcc)
    {
        this.ScriptOutput = script + " ValidateBeforeSaving = false;";
        this.StayContent = "yes";
        return;
    }
