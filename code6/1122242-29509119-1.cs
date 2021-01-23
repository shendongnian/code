    protected virtual void SOOrder_RowSelected(PXCache cache, PXRowSelectedEventArgs e, PXRowSelected del)
        {
            SOOrder row = e.Row as SOOrder;
            if (row == null)
                return;
    
            try{
            if (del != null)
                del(cache, e);
            }
            catch(Exception ex)
            { 
                 //check for surprises
            }
    
           PXUIFieldAttribute.SetEnabled<SOOrderExt.usrContact>(cache, null, true);
        }
