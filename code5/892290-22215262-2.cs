    DataSet dsXml = new DataSet();
    dsXml.ReadXml(new XmlTextReader(new StringReader(xml)));
    List<string> duplicateList = new List<string>();
    foreach (DataRow drow in dsXml.Tables[0].Rows)
    {
        string strr = "";
        for (int j = 0; j < dsXml.Tables[0].Columns.Count; j++ )
        {
            strr += drow[j];
        }
        if (!duplicateList.Contains(strr))
        {
            duplicateList.Add(strr);
        }
        else
        {
            script.Append("alert('Error - There are some Duplicate entries.'); ");
            ErrorOcc = true;
            if (ErrorOcc)
            {
                this.ScriptOutput = script + " ValidateBeforeSaving = false;";
                this.StayContent = "yes";
                return;
            }
        }
    }
