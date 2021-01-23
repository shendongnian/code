    Public class SearchCritera 
    {
        public DateTime? DateOfJoining { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public EmployeeStatus? EmpStatus { get; set; }
    }
    var whereClause = PredicateBuilder.True<tblEmployee>();
    if (searchCriteria.CompanyId.HasValue)
        whereClause = whereClause.And(r => r.CompanyId == searchCriteria.CompanyId);
    if (searchCriteria.CategoryId.HasValue)
        whereClause = whereClause.And(r => r.Category == searchCriteria.CategoryId);
    if (searchCriteria.CategoryId.HasValue)
        whereClause = whereClause.And(r => r.EmpStatus == searchCriteria.EmpStatus);
    if (searchCriteria.DateOfJoining.HasValue)
    {
        var dateClause1 = PredicateBuilder.True<tblEmployee>();
        dateClause1.And(r => r.DateOfJoining <= searchCriteria.DateOfJoining);
        var dateClause2 = PredicateBuilder.True<tblEmployee>();
        dateClause2.And(r => re.DateOfJoining.Value.Month == searchCriteria.DateOfJoining.Month);
        dateClause2.And(r => re.DateOfJoining.Value.Year == searchCriteria.DateOfJoining.Year);
        dateClause1.Or(dateClause2);
        whereClause.And(dateClause1)
    }
    
    var result = ctx.tblEmployee.AsExpandable().Where(whereClause);
