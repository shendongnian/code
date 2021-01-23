            DataSet DropDownListValues = urclassname.GetDates();
			
            DataRow dr;
			
            DropDownList1.Items.Clear();
			
            DropDownList1.Items.Add("");
			
            if (DropDownListValues.Tables[0].Rows.Count > 0)
            {
                int k = 0;
				
                while (k < DropDownListValues.Tables[0].Rows.Count)
                {
                    dr = DropDownListValues.Tables[0].Rows[k];
					
                    string Hours = dr["Hours"].ToString().Trim();
					
                    string Dates = dr["Dates"].ToString().Trim();
					
                    DropDownList1.Items.Add(new ListItem(Hours , Dates));
					
                    k++;
                }
            }
