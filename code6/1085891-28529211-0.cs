    List<TaskDTO> List = null;
    void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["List"] != null) {
            List = (List<TaskDTO>)ViewState["List"];
        } else {
           // ArrayList isn't in view state, so we need to load it from scratch.
            List = TaskList.DrawMenu(int.Parse(Session["emp"].ToString()));
        }
        // Code to create menu, e.g. 
        if (!Page.IsPosBack) {
            Repeater1.DataSource = List;
            Repeater1.DataBind();
        }
    }
    void Page_PreRender(object sender, EventArgs e)
    {
        // Save PageArrayList before the page is rendered.
        ViewState.Add("List", List);
    } 
    ...
    <ul id="orderedList">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li><%# Eval("TaskName") %></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
