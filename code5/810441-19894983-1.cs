    public class Entity
    {
        public int CompanyId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int DateId { get; set; }
    }
    // ...
    List<Entity> res = dbconnect.tblManageDates.Where(i => i.internationalCode == _international).Select(i => new Entity
    {
        CompanyId = i.companyId,
        EndDate = i.endDate,
        StartDate = i.startDate,
        DateId = i.dateId
    }).ToList();
    DataSet dataSet = res.ToDataSet();
