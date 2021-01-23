    private void button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable("Settings"); //we use DataTable class
    
        dt.Columns.Add("ID");
        dt.Columns.Add("Control");
        dt.Columns.Add("ControlName");
        dt.Columns.Add("Top");
        dt.Columns.Add("Left");
        dt.Columns.Add("Width");
        dt.Columns.Add("Height");
        /*
         * You add more settings here
         */
    
    
        int id = 0;
    
        foreach (Control ctrl in this.Controls) //this.Controls is the parent control where the textbox is located
        {
            string c = ctrl.GetType().Name;
            switch (c)
            {
                case "TextBox":
                    DataRow dr = dt.NewRow();
                    dr["ID"] = id++;
                    dr["Control"] = c;
                    dr["ControlName"] = ctrl.Name;
                    dr["Top"] = ctrl.Top;
                    dr["Left"] = ctrl.Left;
                    dr["Width"] = ctrl.Width;
                    dr["Height"] = ctrl.Height;
                    /*
                        * You add more settings here
                        */
                    dt.Rows.Add(dr);
                    break;
            }
        }
    
        dt.WriteXml(@"c:\TestFile.xml", XmlWriteMode.WriteSchema); //You can use save dialog to browse the location
    }
