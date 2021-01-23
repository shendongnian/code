            if(e.Row.RowType == DataControlRowType.DataRow)
            {    
                Button btnAdd = e.Row.FindControl("btnAdd") as Button;
                btnAdd.Attributes.Add("OnClick", "populateLabel();");
            }
        }
