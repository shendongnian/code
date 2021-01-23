    <!-- Place this on the aspx file -->
        <div style="width: 217px; float: left;">
        		<asp:Repeater ID="repeater1" runat="server">
        			<HeaderTemplate>
        				<ul style="list-style: none;">
        			</HeaderTemplate>
        			<ItemTemplate>
        				<li>
        					<%# DataBinder.Eval(Container.DataItem, "cod")%>
        					-
        					<%# DataBinder.Eval(Container.DataItem, "teamName") %>
        					-
        					<%# DataBinder.Eval(Container.DataItem, "score") %></li>
        			</ItemTemplate>
        			<FooterTemplate>
        				</ul>
        			</FooterTemplate>
        		</asp:Repeater>
        	</div>
        	<div style="width: 217px; float: left;">
        		<asp:Repeater ID="repeater2" runat="server">
        			<HeaderTemplate>
        				<ul style="list-style: none;">
        			</HeaderTemplate>
        			<ItemTemplate>
        				<li>
        					<%# DataBinder.Eval(Container.DataItem, "cod")%>
        					-
        					<%# DataBinder.Eval(Container.DataItem, "teamName") %>
        					-
        					<%# DataBinder.Eval(Container.DataItem, "score") %></li>
        			</ItemTemplate>
        			<FooterTemplate>
        				</ul>
        			</FooterTemplate>
        		</asp:Repeater>
        	</div>
    //Place this on the code behind
    protected void Page_Load(object sender, EventArgs e)
    		{
    			List<person> lstPerson = new List<person>();
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "pavan11", score = "40" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "raga11", score = "30" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Sidd11", score = "19" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Ramesh11", score = "11" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Murali11", score = "0" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "madhu11", score = "0" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Sandeep11", score = "0" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Gani11", score = "0" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "prachi", score = "0" });
    			lstPerson.Add(new person() {cod = lstPerson.Count + 1, teamName = "Ani11", score = "0" });
    
    			var part1 = lstPerson.Count / 2;
    
    			repeater1.DataSource = lstPerson.Take(part1).ToList<person>();
    			repeater1.DataBind();
    
    			repeater2.DataSource = lstPerson.Skip(part1).ToList<person>();
    			repeater2.DataBind();
    
    		}
    //The class created for the repeater binding
    public class person
    	{
    		public Int32 cod { get; set; }
    		public String teamName { get; set; }
    		public String score { get; set; }
    	}
