    for (int i = 0; i <= rows - 1; i++)
                {
                    HyperLink MyLink = new HyperLink();
    
                    //Set the Hyperlink Text and ID properties.
                    MyLink.Text = "YOUR TEXT";
                    MyLink.ID = "Link Id";
                    // Add a spacer in the form of an HTML <br /> element.
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                    Panel1.Controls.Add(MyLink);
                }
