    protected string GetAuctionName(string auctionId) 
    {
        Guid id = Guid.Empty;
        Guid.TryParse(auctionId, out id);
      
        using (ModeloEntities modelo = new ModeloEntities())
        {
            var auction_name = (from auctions in modelo.Auctions
                                  where auctions.Auction_ID == id
                                  select auctions).First();
            return auction_name.Auction_Name;
        }
    }
    <ItemTemplate>
        <%# GetAuctionName((string)Eval("Item_BelongToAuction") %>
    </ItemTemplate>
