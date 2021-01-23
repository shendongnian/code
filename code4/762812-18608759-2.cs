	public class ContactLogSummary
    {
        public int ContactLogEntryID { get; set; }
        public int MaternalCaseID { get; set; }
        public String ContactName { get; set; }
        public String OfficeUser { get; set; }
        public DateTime DateAndTimeOfContact { get; set; }
        public String Category { get; set; }
        public String ContactDetails { get; set; }
        public static List<ContactLogSummary> LoadContactListSummary
                                                 (int caseID, String connectionString);
        {
            MyDataContext dbContext = new MyDataContext(connectionString);
            return dbContext.Database.SqlQuery<ContactLogSummary>
                   ("SELECT * FROM dbo.ContactLogSummaries WHERE MaternalCaseID = @CaseID ORDER BY ContactLogEntryID DESC",
                                         new SqlParameter("CaseID", caseID)).ToList();
        }
