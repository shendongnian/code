    public dynamic GetQuotes()
        {
            var ret = (from qt in db.vwUsersQuotess                      
                       select new
                       {
                           Message = qt.Desc,
                           Price= qt.price,
                           Qty = qt.Quantity
                       }).ToList();
            return ret;
        }
