DataColumn myBoolCol = myDataTabel.Columns.Add("MyBoolColumn", typeof(bool));
    public static DataTable  DatePastYesOrNo(DataTable myDataTabel, string kolomNaam)
    {
        foreach(DataRow rij in myDataTabel.Rows)
        {
                string datum = myDataTabel.Rows[0][kolomNaam].ToString();
                DateTime myDatum = DateTime.Parse(datum);
                if (myDatum > DateTime.Now)
                {
                    rij["MyBoolColumn"] = "Y";
                }
                else
                {
                    rij["MyBoolColumn"] = "N";
                }
        }
        return myDataTabel;
     }
