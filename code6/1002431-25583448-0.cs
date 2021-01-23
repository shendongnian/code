    protected void Page_Load(object sender, EventArgs e)
        {
    if(!Page.IsPostBack){
        int id = Convert.ToInt32(Session["DocumentID"]);
        Connection conn = new Connection();
        string query = "SELECT * from Document where DocumentID='" + id + "'";
        SqlCommand sqlcom = new SqlCommand(query, conn.conopen());
        SqlDataAdapter daexp = new SqlDataAdapter(sqlcom);
        System.Data.DataTable dtexp = new System.Data.DataTable();
        daexp.Fill(dtexp);
        TextBox1.Text = dtexp.Rows[0][1].ToString();
        TextBox3.Text = dtexp.Rows[0][2].ToString();
        TextBox6.Text = dtexp.Rows[0][3].ToString();
        TextBox4.Text = dtexp.Rows[0][4].ToString();
        TextBox5.Text = dtexp.Rows[0][5].ToString();
        TextBox7.Text = dtexp.Rows[0][6].ToString();
        TextBox7.ReadOnly = true;
}
    }
