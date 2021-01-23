    MyCollection(TextBox, "ColumnName", "TableName");
    
    public static AutoCompleteStringCollection MyCollection(TextBox txt, string ColumnName, string TableName)
    {
    using (SqlConnection CON = new SqlConnection("ConnectionString"))
            {
                SqlCommand CMD = new SqlCommand("SELECT DISTINCT " + ColumnName + " FROM " + TableName + "", CON);
                CON.Open();
                SqlDataReader Reader = CMD.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (Reader.Read())
                {
                    MyCollection.Add(Reader.GetString(0)).ToString();
                }
                CON.Close();
                return txt.AutoCompleteCustomSource = MyCollection;
            }
        }
