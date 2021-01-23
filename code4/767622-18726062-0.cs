    public void download_Click(Object sender, EventArgs e)
    {
        Response.AddHeader("Content-Type", "application/octet-stream");
        Response.AddHeader("Content-Transfer-Encoding","Binary");
        Response.AddHeader("Content-disposition", "attachment; filename=\"sample.pdf\"");
        Response.WriteFile(HttpRuntime.AppDomainAppPath + @"path\to\file\sample.pdf");
        Response.End();
    }
    <asp:LinkButton ID="download" runat="server" OnClick="download_Click">Download</asp:LinkButton>
