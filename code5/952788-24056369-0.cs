       private void Form1_Load(object sender, EventArgs e)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString())) ;
            {
                cmd = new SqlCommand("update invdata set ViewDate = CURRENT_TIMESTAMP() where InvoiceNumber= '" + inv + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
