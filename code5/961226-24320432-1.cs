	 <asp:GridView ID="grdvDetail" runat="server">
        <Columns>
            <asp:BoundField HeaderText="LectureID" DataField="LectureID" SortExpression="LectureID">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Size="11px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSubject" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    protected void Page_Load(object sender, EventArgs e)
    {	
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            //Fill DataTable Using SQL Query
            grdvDetail.DataSource = dt;
            grdvDetail.DataBind();
            for (int i = 0; i < grdvDetail.Rows.Count; i++)
            {
                DropDownList ddlSubject = ((DropDownList)grvProduct.Rows[i].FindControl("ddlSubject"));
				
				DataTable dtDDL = new DataTable();
				//Fill DataTable Using SQL Query
				ddlSubject.DataSource = dtDDL;
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataValueField = "SubjectName";
                ddlSubject.DataBind();
			}
        }
    }
