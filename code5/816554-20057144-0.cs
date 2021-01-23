    private void Form1_Load(object sender, EventArgs e)
                {
                    // create the panel
                    var panel = new Panel();
                    panel.Location = new Point(100, 100);
                    panel.BorderStyle = BorderStyle.Fixed3D;
                    panel.Width = 240;
                    panel.Height = 210;
        
                    // create a label
                    var company = new Label();
                    company.Location = new Point(panel.Location.X + 10, panel.Location.Y + 10);
                    company.Text = "Company";
        
                    // add the label into panel
                    panel.Controls.Add(company);
        
                    // add the panel into the first tab page of the tab control
                    tabs.TabPages[0].Controls.Add(panel);
                }
