    var qry = from c in dataset.Tables["LinkTable"].AsEnumerable()
        join p in dataset.Tables["products"].AsEnumerable()
            on c.Field<int>("customerId") equals p.Field<int>("customerId") into grp
        from g in grp.DefaultIfEmpty()
        select new {
            //here the collection of columns
            Customer = c.CustomerName,
            Product = grp==null ? String.Empty : grp.ProductName
            };
