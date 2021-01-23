    using ADOX; 
    protected void btnacess_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Student_ID", typeof(Int32));
            dt.Columns.Add("Student_Name", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("City", typeof(string));
            DataRow dtrow = dt.NewRow();
            dtrow["Student_ID"] = 1;
            dtrow["Student_Name"] = "Musakkhir";
            dtrow["Education"] = "MCA";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 2;
            dtrow["Student_Name"] = "Azhar";
            dtrow["Education"] = "M.E";
            dtrow["City"] = "Mumbai";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 3;
            dtrow["Student_Name"] = "Pervaiz";
            dtrow["Education"] = "M.Tech";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 4;
            dtrow["Student_Name"] = "Mustaheer";
            dtrow["Education"] = "M.S.";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ADOX.Catalog cat = new ADOX.Catalog();
            ADOX.Table table = new ADOX.Table();
            //Create the table and it's fields. 
            table.Name = "Table1";
            table.Columns.Append("PartNumber", ADOX.DataTypeEnum.adVarWChar, 60); // text[6]
            table.Columns.Append("AnInteger", ADOX.DataTypeEnum.adInteger, 10); // Integer 
            try
            {
                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=d:/m11.mdb;" + "Jet OLEDB:Engine Type=5");
                cat.Tables.Append(table);
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;" + "Data Source=d:/m11.mdb");
                int i = GridView1.Rows.Count;
                for (int j = 0; j <= i; j++)
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Table1([PartNumber],[AnInteger]) VALUES (@FirstName,@LastName)";
                    cmd.Parameters.Add("@FirstName", OleDbType.VarChar).Value = GridView1.Rows[j].Cells[1].Text;
                    cmd.Parameters.Add("@LastName", OleDbType.VarChar).Value = GridView1.Rows[j].Cells[0].Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            cat = null;
        }
