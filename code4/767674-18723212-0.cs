    private ContextMenuStrip createContextMenuStrip(Card card)
    {
        ContextMenuStrip cms = new ContextMenuStrip();
        cms.Items.Add("Send to the top of the deck", 
                      null, 
                      (sender, e) => sendToDeck(sender, e, card));
        return cms;
    }
    
    public void sendToDeck(object sender, EventArgs e, Card card)
    {
        // **
    }
