public TestItem(IItemServiceRet i)
{
    if(i.Name != null) this.Name = i.Name.GetValue();
    if(i.ORSalesPurchase != null)
        if(i.ORSalesPurchase.SalesOrPurchase != null)
        {
            if(i.ORSalesPurchase.SalesOrPurchase.Desc != null) this.Desc = i.ORSalesPurchase.SalesOrPurchase.Desc.GetValue();
            if(i.ORSalesPurchase.SalesOrPurchase.ORPrice != null)
                if(i.ORSalesPurchase.SalesOrPurchase.ORPrice.Price != null) this.Price = i.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.GetValue();
        }
}</pre>Keep in mind that this does work well for strings, as an empty string is usually the same as a blank field, but for number fields in QuickBooks this may cause problems. For example, an Invoice line can have a blank quantity field (which is a double). A double will default to the value of 0.0, but a blank quantity field in QuickBooks is treated as a quantity of 1.0. This can also cause problems with dates, as QuickBooks can have null date fields.
