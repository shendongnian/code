    public class DomainUserDto
    {
        public string Id { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string Details { get; set; }
    }
    var rows = db.SqlList<DomainUserDto>(
        "EXEC TestJoinSupportForORMLite @Id", new { user.Id });
    rows.PrintDump();
