          string sql1 = "SELECT * from dbo.Documents1 where 1=1";
    
            bool flag = false;
    
            if (!txtRef.Text.Equals(""))
            {
                if (flag == false)
                {
                    sql1 = sql1 + " and Ref LIKE N'%" + txtRef.Text + "%'";
                    flag = true;
    
                }
                else
                {
                    sql1 = sql1 + "  and Ref LIKE N'%" + txtRef.Text + "%'";
                }
            }
