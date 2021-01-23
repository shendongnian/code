    IQueryable<dynamic> sortedGridview = ConvertSortDirectionToSql(e.SortDirection) == "ASC" ?
												(from r in _customers
												 orderby typeof(Customer).GetProperty(column).GetValue(r,null) ascending
												 select new
												 {
													 r.FirstName,
													 r.LastName,
													 r.Company,
													 r.Address,
													 r.City,
													 r.State,
													 r.ZipCode,
													 r.PhoneNumber,
													 r.EmailAddress
												 }).AsQueryable<dynamic>() :
												  (from r in _customers
												   orderby typeof(Customer).GetProperty(column).GetValue(r, null) descending
												   select new
												   {
													   r.FirstName,
													   r.LastName,
													   r.Company,
													   r.Address,
													   r.City,
													   r.State,
													   r.ZipCode,
													   r.PhoneNumber,
													   r.EmailAddress
												   }).AsQueryable<dynamic>();
