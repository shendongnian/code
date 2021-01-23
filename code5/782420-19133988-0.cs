    public string GetSQL()
            {
    
                string sql1 = "SELECT * from dbo.Documents1";
    
                bool flag = false;
    
                if (!txtRef.Text.Equals(""))
                {
                    sql1 = sql1 + " where Ref LIKE N'%" + txtRef.Text + "%'";
                    flag = true;
                }
    
                if (!txtSubject.Text.Equals(""))
                {
                    if (flag == false)
                    {
                        sql1 = sql1 + " where Subject LIKE N'%" + txtSubject.Text + "%'";
                        flag = true;
    
                    }
                    else
                    {
                        sql1 = sql1 + "  and Subject LIKE N'%" + txtSubject.Text + "%'";
                    }
                }
    
                sql1 = sql1 + " order by Received_Date";
    
                return sql1;
            }
 
