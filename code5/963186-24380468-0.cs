    public dynamic GetQuotes()
        {
            var ret = (from qt in db.vwUsersQuotess.ToList()                      
                       select new
                       {
                           Message = qt.Desc,
                           Price= qt.price,
                           Qty = qt.Quantity
                       }).ToList();//use ToList() instead of AsEnumerable()
            return ret;
        }
