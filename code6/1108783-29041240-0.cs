    public void GetPriceLists()
    {
        if (this.EntityId != null)
        {
            SetCustomerNoFromId(this.EntityId, this.EntityType);
            var priceLists = BusinessLayer.Company.GetPriceLists(this.CustomerNo);
            this.PriceListGrid.DataSource = priceLists.ToList(); // here
            this.PriceListGrid.DataBind();
        }
    }
    private void GetPriceLineItems()
    {
        if (this.CurrentPriceListItem != null)
        {
            var priceLineItems = BusinessLayer.Company.GetPriceLineItems(this.CurrentPriceListItem);
            this.PriceLineGrid.DataSource = priceLineItems.ToList(); // and here
            this.PriceLineGrid.DataBind();
        }
    }
