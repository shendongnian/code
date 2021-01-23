    void fillcomboBox1()
    {
    comboBox1.Items.Clear();// <---Add this statement
    if (m_dbConnection != null && m_dbConnection.State == ConnectionState.Closed)
    {
        m_dbConnection.Open();
    }
    SQLiteDataAdapter da = new SQLiteDataAdapter("select * from rdpdirectory order by company asc", m_dbConnection);
    DataTable dt = new DataTable();
    da.Fill(dt);
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        comboBox1.Items.Add(dt.Rows[i]["Company"]);
    }
    m_dbConnection.Close();
    }
