    for (int i = 0; i <= rows - 1; i++)
                {
                    HyperLink MyLink = new HyperLink();
    
                    //Set the Hyperlink Text and ID properties.
                    MyLink.Text = "        " + admission.Rows[i][0].ToString() + " " + admission.Rows[i][1].ToString() + " " + admission.Rows[i][2].ToString() + " " + admission.Rows[i][3].ToString();
                    MyLink.ID = admission.Rows[i][0].ToString();
                    username = admission.Rows[i][3].ToString();
                    string Refno = HttpUtility.UrlEncode(Encrypt(admission.Rows[i][0].ToString()));
                    MyLink.NavigateUrl = string.Format("FrmUserRequest.aspx?RefNo={0}",Refno);
                    // Add a spacer in the form of an HTML <br /> element.
                    Panel1.Controls.Add(new LiteralControl("<br />"));
                    Panel1.Controls.Add(MyLink);
                }
