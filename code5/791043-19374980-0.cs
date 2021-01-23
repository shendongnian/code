    <asp:Label ID="lblMsg" runat="server"></asp:Label>
..
    try{
        sendMail(toemail);
    }
    catch(Exception ex){
        lblMsg.Text = ex.Message; // or whatever message you want to show
        lblMsg.ForeColor = Color.Red // Red shows error
    }
    
    ...
    
    public void sendMail(String toemail){
        try{
            ...
        }
        catch(Exception ex){
            throw ex; // Don't use Response.Write
        }
    }
