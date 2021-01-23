    var q =
        from a in dc.GetTable<invoice_in>()
        join b in dc.GetTable<supplier>()
            on a.supplier_id equals b.id
        select a;
    //since you compared date_from against null I assume it is Nullable<DateTime>
    if (date_from.HasValue)
        {
            q = q.Where(a => a.invoice_date >= date_from.Value);
        }
    var result = 
    q.Select(a => new Invoice_in(a.id, a.amount ?? 0, 
                                 a.invoice_number ,
                                 a.supplier_id ?? 0, 
                                 a.supplier.s_name,
                                 a.invoice_date ?? System.DateTime.Today))
     .ToList();
