    private void button2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable("Settings");
    
        dt.ReadXml(@"c:\TestFile.xml");
    
        foreach (DataRow dr in dt.Rows)
        {
            switch (dr["Control"].ToString())
            {
                case "TextBox":
                    var t = new TextBox();
                    t.Name = dr["ControlName"].ToString();
                    t.Top = Convert.ToInt32(dr["Top"]);
                    t.Left = Convert.ToInt32(dr["Left"]);
                    t.Width = Convert.ToInt32(dr["Width"]);
                    t.Height = Convert.ToInt32(dr["Height"]);
    
                    this.Controls.Add(t);
                    break;
            }
        }
    
    }
