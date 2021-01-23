        int sum=0;
        protected void GridView2_RowDataBound(object sender,  GridViewRowEventArgs e)
             {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label salary = (Label)e.Row.FindControl("Label3");//take lable id
                sum +=int.Parse(salary.Text);
                lblsum.Text = sum.ToString();
            }
        }
