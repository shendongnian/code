    public class EmployeeMap : ClassMap<EmployeeNHEntity>
    {
        public EmployeeMap()
        {
            Schema("dbo");
            Table("Employee");
            Id(x => x.EmployeeUUID).GeneratedBy.GuidComb().Index("IX_Employee_EmployeeUUID_And_SSN");
            Map(x => x.SSN).Index("IX_Employee_EmployeeUUID_And_SSN");
            Map(x => x.LastName);
            Map(x => x.FirstName);
