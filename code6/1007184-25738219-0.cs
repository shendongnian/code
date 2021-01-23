    if (e.CommandName == "viewDetail")
                {
                    int DetailID = Convert.ToInt32(e.CommandArgument.ToString());
                    using (VIPCRMEntities dbc = new VIPCRMEntities())
                    {
                        Solution selDetail = (from c in dbc.Solutions
                                              where c.Soln_SolutionId == DetailID
                                              select c).First();
                        InfoModal.Show();
                        lblInfoText.Text = selDetail.Soln_SolutionDetails;
                    }
                }
                else if (e.CommandName == "viewDoc")
                {
                    int DetailID = Convert.ToInt32(e.CommandArgument.ToString());
                    using (VIPCRMEntities dbc = new VIPCRMEntities())
                    {
                        Solution selDetail = (from c in dbc.Solutions
                                              where c.Soln_SolutionId == DetailID
                                              select c).First();
                        InfoModal.Show();
                        lblInfoText.Text = selDetail.soln_link;
                    }               
                }
