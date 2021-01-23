     AreaClassification.SummaryForSelectedItemsDelegate += SummarizeTeams;
    protected string SummarizeTeams(IList selection)
            {
                string str = "*None Selected*";
    
                if (null != selection && selection.Count > 0)
                {
                    StringBuilder contents = new StringBuilder();
                    int idx = 0;
                    foreach (object o in selection)
                    {
                        if (idx > 0) contents.Append(", ");
                        contents.Append(((Area)o).name);
                        idx++;
                    }
                    str = contents.ToString();
                }
    
                return str;
            }
