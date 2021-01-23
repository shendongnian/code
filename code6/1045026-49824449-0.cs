     <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%#Eval("notice")%>' runat="server" onclick = "lnkDownload_Click" ></asp:LinkButton>
            &nbsp;&nbsp;
             <asp:LinkButton ID="btnOpen" Text="View" CommandArgument='<%#Eval("notice")%>' Font-Bold="true" runat="server" onclick = "btnOpen_Click"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath.Substring(0)));
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void btnOpen_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = "Application/pdf";
            //Get the physical path to the file.
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            // Write the file directly to the HTTP content output stream.
            Response.Redirect(filePath);
            Response.End();
        }
