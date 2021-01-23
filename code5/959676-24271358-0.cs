    string ID_Sel = "SELECT TOP 1 columnID FROM table ORDER BY columnID";
    string ID_Ins = "INSERT INTO table (columnID) VALUES (@id)";
    SqlConnection con = new SqlConnection(connection string);
    SqlCommand cmdsel = new SqlCommand(ID_Sel, con);
    SqlCommand cmdins = new SqlCommand(ID_Ins, con);
    con.Open();
    var a = cmdsel.ExecuteScalar();  // use ExecuteScalar to get the only value
    int b = Convert.ToInt32(a) + 1;
    textBox.Text = b;
    con.Close();
    textBox.Attributes.Add("readonly", "readonly");
    try
    {
        con.Open();
        cmdins.Parameters.AddWithValue("@id", b);   //  use the variable instead of the TextBox property.
        cmdins.ExecuteNonQuery();
        con.Close();
    }
    catch(Exception ex)
    {
    error.Text = ex.Message;
    }
