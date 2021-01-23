    protected void btnUpdate2_click(object sender, EventArgs e)
            {
                try
                {
                    Button ib = (Button)sender;
                    // string index = (ib.CommandName);
                    RepeaterItem gr = (RepeaterItem)ib.NamingContainer;
                    int index = gr.ItemIndex;
        
                    property.banner_type = "Primary";
                    property.active = Convert.ToBoolean(((CheckBox)rpt_slider.Items[index].FindControl("checkActive")).Checked);
                    property.banner_index = Convert.ToInt32(((DropDownList)rpt_slider.Items[index].FindControl("drop_IndexNo")).SelectedValue);
                    property.banner_id = Convert.ToInt32(ib.CommandArgument);
                    property.bottom_pos = Convert.ToInt32(((TextBox)rpt_slider.Items[index].FindControl("txtBPOS")).Text);
                    property.right_pos = Convert.ToInt32(((TextBox)rpt_slider.Items[index].FindControl("txtRPOS")).Text);
                    property.cr_user = Convert.ToInt32(Session["admin_id"]);
                    property.cr_date = Convert.ToDateTime(DateTime.Now.ToString());
                    property.banner_text = Convert.ToString(((HtmlEditor)rpt_slider.Items[index].FindControl("Htmleditor1")).Text);
                    property.tag = 2;
                    try
                    {
                        int result = 0;
                        result = balss.banner_insert(property.banner_id, property.banner_type, "", "", property.active, property.banner_index, property.cr_user, property.cr_date, property.banner_text, property.bottom_pos, property.right_pos, property.tag);
                        if (result > 0)
                        {
                            ClientScript.RegisterStartupScript(this.up1.GetType(), "Script", "<script type='text/javascript'>alert('Record Updated successfully.');</script>");
        
                        }
        
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "<script text='text/javascript'> alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                    }
                    getdata();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert(' " + ex.Message + "');</script>", false);
                }
                finally
                {
                }
                Response.Redirect("edit_banner");
        
        
            }
    on button submit click i am used 
     property.banner_text = Convert.ToString(((HtmlEditor)rpt_slider.Items[index].FindControl("Htmleditor1")).Text);
    for get value of html editor for repeater.
