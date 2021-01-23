         public partial class WebForm1 : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
        
                }
                public static DataTable dt;
                public static int i = 1;
                protected void btnInsert_Click(object sender, EventArgs e)
                {
                    if (Convert.ToString(ViewState["Row"]) != "")
                    {
                        dt.Rows[Convert.ToInt32(ViewState["Row"])]["Column1"] = TxtName.Text;
                        dt.Rows[Convert.ToInt32(ViewState["Row"])]["Column2"] = txtAge.Text;
                        grdView.DataSource = dt;
                        grdView.DataBind();
                        ViewState["Row"] ="";
                       
                    }
                    else if(Convert.ToString(ViewState["Row"]) == "")
                    {
                        Session["datatable"] = dt;
                        dt = new DataTable();
                        DataRow dr = null;
                        dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
                        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
                        //
                        if (Session["datatable"] != null)
                        {
        
                            dt = (DataTable)Session["datatable"];
                            dr = dt.NewRow();
                            dr["RowNumber"] = i;
                            dr["Column1"] = TxtName.Text;
                            dr["Column2"] = txtAge.Text;
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr["RowNumber"] = i;
                            dr["Column1"] = TxtName.Text;
                            dr["Column2"] = txtAge.Text;
                            dt.Rows.Add(dr);
                        }
        
                        grdView.DataSource = dt;
                        grdView.DataBind();
                        i++;
                    }
                }
        
                //protected void btn_Click(object sender, EventArgs e)
                //{
                //    dt = (DataTable)Session["datatable"];
                //    if (dt.Rows.Count > 0)
                //    {
                       
                //        dt.Rows.RemoveAt(Convert .ToInt16 ( grdView.SelectedRow) );
                //        grdView .DataSource = dt;
                //        grdView.DataBind();
                       
                //    }
                //}
        
                protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
                {
                    if (e.CommandName == "delete")
                    {
                        dt = (DataTable)Session["datatable"];
                        if (dt.Rows.Count >= 0)
                        {
        
                            dt.Rows.RemoveAt(Convert.ToInt16(e.CommandArgument ));
                            grdView.DataSource = dt;
                            grdView.DataBind();
        
                        }
                       
                    }
                    else if (e.CommandName == "Change")
                    {
                        dt = (DataTable)Session["datatable"];
                      //  TxtName.Text = (string)dt.Rows[grdView.SelectedIndex]["Column1"];
                        TxtName.Text = grdView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                        txtAge.Text = grdView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                        ViewState["Row"] = e.CommandArgument;
                        if (dt.Rows.Count >= 0  )
                        {
                      
                            //dt.Rows[grdView.SelectedIndex]["Column1"] = TxtName.Text;
                            //dt.Rows[grdView.SelectedIndex]["Column2"] = txtAge.Text;
                            grdView.DataSource = dt;
                            grdView.DataBind();
                        }
        
                    }
                }
        
                protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
                {
                    grdView.DataSource = dt;
                    grdView.DataBind();
                }
        
                protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
                {
                    TxtName.Text = grdView.SelectedRow.Cells[2].Text;
                }
        
                //protected void btnUpdate_Click(object sender, EventArgs e)
                //{
                //    dt.Rows[Convert.ToInt32(ViewState["Row"])]["Column1"] = TxtName.Text;
                //    dt.Rows[Convert.ToInt32(ViewState["Row"])]["Column2"] = txtAge.Text;
                //    grdView.DataSource = dt;
                //    grdView.DataBind();
                //}
        
               
            }
    
    
    
    
       
    
     <div>
        Name    <asp:TextBox ID="TxtName" runat="server" ></asp:TextBox>
           Age<asp:TextBox ID="txtAge" runat="server" ></asp:TextBox>
            <asp:Button ID="btnInsert" Text="Save"  runat="server" OnClick="btnInsert_Click"  />
          <%--  <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" />--%>
        <asp:GridView ID="grdView" runat="server" OnRowCommand="grdView_RowCommand" OnRowDeleting="grdView_RowDeleting" 
    >
            <Columns>
                <asp:TemplateField>
                   
                    <ItemTemplate>
                        <asp:Button ID="btn" runat="server" Text="Delete"  CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
             <%--   <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                </ItemTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="Change" ID="btnEdit" Text="Edit" CommandArgument='<%# Container.DataItemIndex %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
