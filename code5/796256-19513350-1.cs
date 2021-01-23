	var query=from c in customer.AsEnumerable()
	         join uc in updatedCustomer.AsEnumerable()
			 on c.Field<int>("ID") equals uc.Field<int>("ID") into lf
			 from uc in lf.DefaultIfEmpty()
			 select new
			 {
				 ID=c.Field<int>("ID"),
				 Address=uc==null?c.Field<string>("Address"):uc.Field<string>("Address")
			 };
    //this will get the result you want,but it is not DataTable.
    //you need to convert query to datatable .
	DataTable result =customer.Clone();
	
	query.ToList().ForEach(q=>result.Rows.Add(q.ID,q.Address));
