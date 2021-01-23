    foreach(var i in invoices)
    {
        foreach(var l in i.LineItems)
        {
            l.Invoice = i;
            foreach(var a in l.Allocations)
            {
                a.LineItem = l;
            }
        }
    }
