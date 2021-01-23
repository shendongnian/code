     for(int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    HtmlGenericControl divStatus = (HtmlGenericControl)fileBrowserGrid.Rows[i].FindControl("divStatus");
                    
                    if(dataSet.Tables[0].Rows[i]["LoadStatus"].ToString() != "Failed")
                         divStatus.InnerHtml = dataSet.Tables[0].Rows[i]["LoadStatus"].ToString();
                    else
                         divStatus.InnerHtml = "<a href='pageURL.aspx?ID=" + dataSet.Tables[0].Rows[i]["LoadedFileID"].ToString() + "'> Failed : " + dataSet.Tables[0].Rows[i]["LoadedFileID"].ToString() + "</a>";
                }
