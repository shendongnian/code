    private object lockableThing; // Created in the ctor
    public bool ReduceStockLevelForSale(int qtySold)
    {
        bool success = false;
        if (this.quantityOnHand >= qtySold)
        {
            lock (lockableThing)
            {
                if (this.quantityOnHand >= qtySold)
                {
                    this.quantityOnHand -= qtySold;
                    success = true;
                }
            }
        }
        return success;
    }
