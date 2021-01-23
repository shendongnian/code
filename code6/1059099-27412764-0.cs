    protected void Button1_Click(object sender, EventArgs e)
    {
        ID = TextBox1.Text;
        List<dataclass> returnedData = Getdata(ID);
        foreach (var dc in returnedData)
        {
            // Do something with dc.idd, dc.datetime, dc.col1, dc.col2, dc.col3
        }
    }
    public static List<dataclass> Getdata(string ID)
