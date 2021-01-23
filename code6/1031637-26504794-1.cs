    <%@ Page Language="C#" AutoEventWireup="true" %>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create some test data to play with.
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("xtid", typeof(int));
            table.Columns.Add("timg", typeof(string));
            table.Columns.Add("ALERT", typeof(string));
            table.Rows.Add(1, "/some_img.jpg", "YES");
            table.Rows.Add(2, "/some_img.jpg", "NO");
            table.Rows.Add(3, "/some_img.jpg", "NO");
            table.Rows.Add(4, "/some_img.jpg", "YES");
            MyListView.DataSource = table;
            MyListView.DataBind();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // output the id of the button clicked.
            ButtonClicked.Text = ((Control)sender).ID;
        }
        protected void MyListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var row = (System.Data.DataRowView)e.Item.DataItem;
            // Find the link button on the item's template.
            var linkButton = e.Item.FindControl("LinkButton1") as LinkButton;
            if (linkButton != null)
            {
                linkButton.ID = row["xtid"].ToString();
                var buttonText = linkButton.FindControl("ButtonText") as Label;
                if (buttonText != null)
                {
                    if (row["ALERT"].ToString() == "YES")
                    {
                        buttonText.Text = "STH";
                    }
                }
                var image1 = linkButton.FindControl("Image1") as Image;
                if (image1 != null)
                {
                    image1.ImageUrl = row["timg"].ToString();
                    image1.ID = "img" + row["xtid"];
                }
            }
        }
    </script>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server" ID="ScriptManager1" />
            <div>
                <asp:Label runat="server" ID="ButtonClicked" />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ListView runat="server" ID="MyListView" OnItemDataBound="MyListView_ItemDataBound">
                            <LayoutTemplate>
                                <ul class="slides">
                                    <asp:PlaceHolder runat="server" ID="ItemPlaceHolder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <%-- The item template is used to render each of the rows of the DataTable that has been binded to the ListView control. --%>
                                <div class="ft-item">
                                    <span class="ft-image">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                            <asp:Label runat="server" ID="ButtonText" />
                                            <asp:Image ID="Image1" runat="server" />
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        </span>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </body>
    </html>
