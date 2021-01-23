     private string GetCheckedEvents()
        {
            List<string> outputString = new List<string>();
            foreach (GridViewRow row in GridView1.Rows)
            {
              if (row.RowType == DataControlRowType.DataRow)
              {
                  CheckBox cb = (CheckBox)row.FindControl("eventSelected");
                  if (cb != null && cb.Checked)
                  {
                      long eventID= long.Parse(GridView1.DataKeys[row.RowIndex].Values["EventID"].ToString());
                      outputString.Add(eventID);
                  }
              }
            }
            return string.Join(",", outputString);
        }
