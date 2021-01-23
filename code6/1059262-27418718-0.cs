    protected void Button1_Click(object sender, EventArgs e)
    {
        var sbText1 = new StringBuilder();
        var sbText2 = new StringBuilder();
        var sbText3 = new StringBuilder();
        var returnedData = Getdata();
        foreach (var dataclass0 in returnedData)
        {
            sbText1.AppendLine(dataclass0.item1);
            sbText2.AppendLine(dataclass0.item2);
            sbText3.AppendLine(dataclass0.item3);
        }
        TextBox1.Text = sbText1.ToString().Replace(Environment.NewLine, ", ");
        TextBox2.Text = sbText2.ToString().Replace(Environment.NewLine, ", ");
        TextBox3.Text = sbText3.ToString().Replace(Environment.NewLine, ", ");
    }
