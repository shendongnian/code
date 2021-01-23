    private void listNotMatchedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
           string table =String.Empty;
           if(listNotMatchedItems.SelectedItems.Count>0)   
           {  
             using (SqlConnection con = new SqlConnection(strConnectDB1))
             {
                con.Open();
 
 
                   using (SqlCommand comQuery = new SqlCommand(@" declare @vsSQL varchar(8000)
                   declare @vsTableName varchar(50)
                   select @vsTableName = @TT
                   select @vsSQL = 'CREATE TABLE ' + @vsTableName + char(10) + '(' + char(10)
                   select @vsSQL = @vsSQL + ' ' + sc.Name + ' ' +
                   st.Name +
                   case when st.Name in ('varchar','varchar','char','nchar') then '(' + cast(sc.Length as varchar) + ') ' else ' ' end +
                   case when sc.IsNullable = 1 then 'NULL' else 'NOT NULL' end + ',' + char(10)
                   from sysobjects so
                   join syscolumns sc on sc.id = so.id
                   join systypes st on st.xusertype = sc.xusertype
                   where so.name = @vsTableName
                   order by
                   sc.ColID
                   select substring(@vsSQL,1,len(@vsSQL) - 2) + char(10) + ')'", con))
   
               {
 
                  comQuery.Parameters.AddWithValue("@TT", listNotMatchedItems.SelectedItem);
 
                    using (SqlDataReader readerQuery = comQuery.ExecuteReader())
 
                    {
 
                        txtNotMachedQuery.Text = "";
                        int a = 0;
 
                        while (readerQuery.Read())
                        {
                            a++;
                          txtNotMachedQuery.Text = readerQuery[0].ToString() ;
 
 
                        }
                   
                   
                   
                    }
 
               
                }
 
 
 
 
                using (SqlCommand com = new SqlCommand(@"SELECT * FROM " + table, con))
                {
 
 
 
                    using (SqlDataReader reader = com.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        listNotMachedFields.Items.Clear();
                        DataTable schemaTable = reader.GetSchemaTable();
                        foreach (DataRow colRow in schemaTable.Rows)
                            listNotMachedFields.Items.Add(colRow.Field<String>("ColumnName"));
 
 
 
                       }
               
                   }
                 }
                }//if end
            }
   
