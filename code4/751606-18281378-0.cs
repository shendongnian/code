     protected void Page_Load(object sender, EventArgs e)
            {
                AddDiv();
            }
    
            public void AddDiv()
            {
                for (int i = 0; i < 5; i++)
                {
                    HtmlGenericControl newControl = new HtmlGenericControl("div");
                    newControl.ID = "div" + i;
                    AddLabel(newControl, i);
                    PlaceHolder1.Controls.Add(newControl);
                }
                
            }
    
            protected void AddLabel(HtmlGenericControl control, int i)
            {
                Label lblTitle = new Label();
                lblTitle.Text = "label" + i.ToString();
                control.Controls.Add(lblTitle);
    
                Label lblPublisher = new Label();
                lblPublisher.Text = "publisherLabel" + i.ToString();
                control.Controls.Add(lblPublisher);
            }
