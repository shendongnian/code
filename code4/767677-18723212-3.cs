    private ContextMenuStrip createContextMenuStrip(Card card)
    {
        ContextMenuStrip cms = new ContextMenuStrip();
        cms.Items.Add("Send to the top of the deck", 
                      null, 
                      (sender, e) => sendToDeck(card));
        return cms;
    }
    
    public void sendToDeck(Card card)
    {
        // **
    }
