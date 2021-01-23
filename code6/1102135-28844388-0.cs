    public interface ITimesheetsContext
    {
        IDbSet<Timesheet> Timesheets { get; set; }
    }
    public interface ITimesheetRepository
    {
        void Add(Timesheet sheet);
    }
    public class DbTimesheetRepository : ITimesheetRepository
    {
        public ITimesheetsContext _context;
        public DbTimesheetRepository(ITimesheetsContext context)
        {
            _context = context;
        }
        public void Add(Timesheet ts)
        {
            _context.Timesheets.Add(ts);
        }
    }
      [TestFixture]
      public class DbTimesheetRepositoryTests
      {
          public void Add_CallsSetAdd()
          {
              // Arrange
              var timesheet = new Timesheet();
              var timesheetsMock = new Mock<IDbSet<Timesheet>>();
              timesheetsMock.Setup(t => t.Add(timesheet)).Verifiable();
              var contextMock = new Mock<ITimesheetsContext>();
              contextMock.Setup(x => x.Timesheets).Returns(timesheetsMock.Object);
              var repo = new DbTimesheetRepository(contextMock.Object);
              // Act
              repo.Add(timesheet);
              // Assert
              timesheetsMock.Verify(t => t.Add(timesheet), Times.Once);
          }          
      }
