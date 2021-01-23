    SqlCommand querySaveStaff = new SqlCommand(saveStaff);
    querySaveStaff.Connection = opencon;
    querySaveStaff.Parameters.Add("@AlbergoName", SqlDbType.NChar, 30);
    foreach (var nodo in document)
    {
        string nome = nodo.SelectSingleNode("./h3[1]/a[1]").InnerText;
        Console.WriteLine(nome);
        querySaveStaff.Parameters["@AlbergoName"].Value = nome;
        querySaveStaff.ExecuteNonQuery();
    }
