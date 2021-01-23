    private string CreateXML(DataTable table1, DataTable table2)
        {
            System.Text.StringBuilder sp = new System.Text.StringBuilder();
    
            sp.Append("<root>");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
    
                sp.Append("<member>");
                sp.Append("<refid>" + table1.Rows[i]["refid"] + "</refid>");
                sp.Append("<fname>" + table1.Rows[i]["fname"] + "</fname>");
                sp.Append("<lname>" + table1.Rows[i]["lname"] + "</lname>");
    
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    if (table1.Rows[i]["refid"] == table2.Rows[j]["refid"])
                    {
                        sp.Append("<activities>");
                        sp.Append("<refid>" + table2.Rows[j]["refid"] + "</refid>");
                        sp.Append("<act>" + table2.Rows[j]["act"] + "</act>");
    
                        sp.Append("</activities>");
                    }
                }
    
                sp.Append("<Date>" + table1.Rows[i]["Date"] + "</Date>");
                sp.Append("</member>");
            }
    
            sp.Append("</root>");
            return sp.ToString();
        }
