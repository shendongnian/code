       private DataSet selectID(string studentId)
                {
                    SqlConnection conn = "connecttoserverstring";
                    SqlCommand cmd = new SqlCommand("select 'M-' + cast(ID as varchar(10)) from table, conn);            
                    SqlParameter p = new SqlParameter("@id", studentId);
        			}
    		
