    void btnInstaAuth_Click(Object sender,
                                   EventArgs e)
            {
                btnGetInstaPosts.Visible = false;
                if (SesssionInstaUser.isInSession())
                {
                    SesssionInstaUser.clear();
                    Button clickedButton = (Button)sender;
                    clickedButton.Text = "Click here to get instagram auth";
                    btnInstaAuth.Visible = true;
                }
                else
                {
                    Response.Redirect(AuthManager.genUserAutorizationUrl());
                }
            }
