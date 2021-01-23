    private void Form1_Load(object sender, EventArgs e)
    {
      listView1.View = View.Details;
      listView1.Columns.Add("Number", 50, HorizontalAlignment.Left);
      listView1.Columns.Add("Bet", 50, HorizontalAlignment.Left);
    }
