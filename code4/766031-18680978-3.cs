    protected void seat_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.BackColor == Color.Cyan)
        {
            button.BackColor = Color.Lime;
            addSeat(button.Text);
        }
    }
    private void addSeat(string seatNo)
    {
        if (Session["dt"] == null)
        {
            Response.Write("DataTable not exist!");
            return;
        }
        DataTable dtSelectedSeats = (DataTable)Session["dt"];
        DataRow dr = dtSelectedSeats.NewRow();
        dr["catID"] = ddlCategory.SelectedItem.Value.ToString();
        dr["seatID"] = seatNo;
        dtSelectedSeats.Rows.Add(dr);
        GridView1.DataSource = dtSelectedSeats;
        GridView1.DataBind();
        Session["dt"] = dtSelectedSeats;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtSelectedSeats = new DataTable();
            dtSelectedSeats.Columns.Add("catID", typeof(string));
            dtSelectedSeats.Columns.Add("seatID", typeof(string));
            Session["dt"] = dtSelectedSeats;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        seat_Click(sender, e);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        seat_Click(sender, e);
    }
   
