    public IPagedList<Inv_AMC> Gets(int? page, int? pageSize, string sort = "Id", string sortdir = "DESC", string searchKey = "")
            {
                int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                int pageSizeValue = pageSize.HasValue ? Convert.ToInt32(pageSize) : 10;
                return dbSet.Where(x => (x.Customer.CustomerName.ToUpper().Contains(searchKey.ToUpper()) || searchKey == ""))
                      .OrderBy(sort + " " + sortdir)
                      .ToPagedList(pageIndex, pageSizeValue);
            }
