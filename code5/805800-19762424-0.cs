     public IQueryable<Cwzz_CashFlowItem> AllDataPage(...) {
        IQueryable<Cwzz_CashFlowItem> ll =  _ctx.Cwzz_CashFlowItem;
        
        if (xmbmLike != "")
        {
          ll = ll.Where(v => v.CashFlowCode.Contains(xmbmLike));
        }
        if (xmcmLike != "")
        {
          ll = ll.Where(v => v.CashFlowCode.Contains(xmcmLike));
        }
        
        return ll.OrderBy(v => v.CashFlowCode).Skip(start).Take(limit);
       }
