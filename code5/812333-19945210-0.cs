    private DataTable _dtQuery = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	_dtQuery = ResultFromQuery();
    
    	var dtUnique = dt.DefaultView.ToTable(true, "Team1"); // this will hold 3 rows which are eagle, snake, bull
    	GridView1.DataSource = dtUnique;
    	GridView1.DataBind;
    }
    
    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
    	GridViewRow gvRow = e.Row;
    	if (gvRow.RowType == DataControlRowType.DataRow) {
    		var dr = (DataRow)gvRow.DataItem;
    		
    		var dtSource = sender.DataSource();
    		var iRowCount = dtSource.Rows.Count;
    		
    		for(var j = 0; j < iRowCount; j++) {
    			var sTeam1 = dtSource.Rows(j)("Team1");
    			
    			for(var i = 0; i < iRowCount; i++) {
    				var sTeam2 = dtSource.Rows(i)("Team1");
    				
    				var dv = _dtQuery.DefaultView();
    				dv.RowFilter = string.Format("Team1 = '{0}' AND Team2 = '{1}'", sTeam1, sTeam2);
    				var dt = dv.ToTable();
    				
    				if(dt.Rows.Count > 0) {
    					((Literal)gvRow.FindControl("lit" + sTeam2)).Text = dt.Rows(0)("Result").ToString();
    				}
    			}
    		}
    	}
    }
    
    
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    	<Columns>
    		<asp:TemplateField HeaderText="Eagle">
    			<ItemTemplate>
    				<asp:Literal runat="server" ID="litEagle" />
    			</ItemTemplate>
    		</asp:TemplateField>
    		<asp:TemplateField HeaderText="Bull">
    			<ItemTemplate>
    				<asp:Literal runat="server" ID="litBull" />
    			</ItemTemplate>
    		</asp:TemplateField>
    		<asp:TemplateField HeaderText="Snake">
    			<ItemTemplate>
    				<asp:Literal runat="server" ID="litSnake" />
    			</ItemTemplate>
    		</asp:TemplateField>
    	</Columns>
    </asp:GridView>
