    protected void AddBtn_Click1(object sender, EventArgs e)
    {
    
        string text1 = TextBox1.Text;
        string text2 = TextBox2.Text;
        string text3 = TextBox3.Text;
        string text4 = TextBox4.Text;
        string text5 = TextBox5.Text;
        string text6 = TextBox6.Text;
        string text7 = TextBox7.Text;
        string text8 = TextBox8.Text;
        string text9 = TextBox9.Text;
    
    
        if (pnAvailiable == 1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["XMLConnectionString"].ConnectionString);
            con.Open();
            string str = "INSERT INTO XML (Part_Number, PowerMin_dBm_RoomTemp, PowerMax_dBm_RoomTemp, ERMin_dB_RoomTemp, ERMax_dB_RoomTemp, OMAMin_uW_RoomTemp, OMAMax_uW_RoomTemp, ModPowerConsumptionMin_W_RoomTemp, ModPowerConsumptionMax_W_RoomTemp) VALUES (@text1,@text2,@text3,@text4,@text5,@text6,@text7,@text8,@text9)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@text1", text1);
            cmd.Parameters.AddWithValue("@text2", text2);
            cmd.Parameters.AddWithValue("@text3", text3);
            cmd.Parameters.AddWithValue("@text4", text4);
            cmd.Parameters.AddWithValue("@text5", text5);
            cmd.Parameters.AddWithValue("@text6", text6);
            cmd.Parameters.AddWithValue("@text7", text7);
            cmd.Parameters.AddWithValue("@text8", text8);
            cmd.Parameters.AddWithValue("@text9", text9);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
