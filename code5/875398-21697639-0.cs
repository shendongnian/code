    List<string> dates=new List<string>();
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
       dates.add(Calendar1.SelectedDate.ToShortDateString());
       GridView2.DataSource=dates;
       GridView2.DataBind();
    }
   
