    class EmploymentDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string FirstName { get; set; }
    }
    EmploymentDto dto = null;
    Employee employee = null;
    var employments = session.QueryOver<Store>()
        .Where(shop => shop.Id == 1)
        .JoinAlias(s => s.Staff, () => employee)
        .SelectList(l =>
            l.Select(s => s.Id).WithAlias(() => dto.StoreId)
            l.Select(s => s.Name).WithAlias(() => dto.StoreName)
            l.Select(() => employee.FirstName).WithAlias(() => dto.FirstName)
        .TransformUsing(Transformers.AliasToBean<EmploymentDto>())
        .List<EmploymentDto>();
