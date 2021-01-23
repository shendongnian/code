                    if (Page.Request.Params["__EVENTTARGET"].ToString().ToLower().Contains("btncheck"))
                    {
                        string[] arg = Page.Request.Params["__EVENTARGUMENT"].ToString().Split(',');
                        lsvSearchResult.DataSource = null;
                        lsvSearchResult.DataBind();
                        if (Convert.ToString(arg[0]) == "IDNO")
                        {
                            if (Convert.ToString(arg[1]).Trim() != "")
                            { 
                                lsvSearchResult.DataSource = GetStudents(arg[0], arg[1]);
                                lsvSearchResult.DataBind();
                            }
                        }
                        else if (Convert.ToString(arg[0]) == "NAME")
                        {
                            lsvSearchResult.DataSource = GetStudents(arg[0], arg[1]);
                            lsvSearchResult.DataBind();
                        }
                    }
                    //GetStudents(arg[0], arg[1]);
                }
                else if (Page.Request.Params["__EVENTTARGET"].ToString().ToLower().Contains("btncancemodal"))
                {
                    try
                    {
                        txtSearch.Text = string.Empty;
                        //lsvSearchResult.Items.Clear();
                        DataSet ds = null;
                        lsvSearchResult.DataSource = ds;
                        lsvSearchResult.DataBind();
                    }
                    catch (Exception)
                    {
                        // error
                    }
                }
            }
