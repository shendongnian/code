    for (int i = 0; i < pinArray.Length; i++)
    {
        if (pinArray[i] != null)
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand("Update PostParcel set Pin=@pin1 where Box='1'and Pin!= '' ", myConnect);
            cmd.Parameters.AddWithValue("@pin1", RandomNumber(1000, 9999));
            myConnect.Open();
            cmd.ExecuteNonQuery();
            myConnect.Close();
            assigned = true;
        }
    }
    if (!assigned)
    {
        pinArray[i] = txtpBox1.Text;
        MessageBox.Show("Invalid Pin. A new one will be assigned");
        break;
    }
