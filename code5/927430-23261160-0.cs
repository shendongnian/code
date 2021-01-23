             protected void Page_Load(object sender, EventArgs e)
                       {
                        if (Request.QueryString["Data"] != null)
                           {
                                Search.Visible = false;
                              pnlSearchResult.Visible = true;
                            }
                        }
