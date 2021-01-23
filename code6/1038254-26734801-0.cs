    [TestFixture]
    public class StudentServiceTest
    {
    	private Mock<StudentRepository> _studentRepositoryMock;
    	private Mock<SubjectRepository> _subjectRepositoryMock;
    	private Mock<StudentService> _studentServiceMock;
    
    	[SetUp]
    	public void Setup()
    	{
    		_studentRepositoryMock = new Mock<StudentService>(MockBehavior.Strict);
    		_subjectRepositoryMock = new Mock<SubjectRepository>(MockBehavior.Strict);
    		_studentServiceMock = new Mock<StudentService>(_studentRepositoryMock.Object, _subjectRepositoryMock.Object);
    		_studentServiceMock.CallBase = true;
    	}
    
    	[TearDown]
    	public void TearDown()
    	{
    
    	}
    	
    	[Test]
    	public void GetRankTest()
    	{
    		_studentServiceMock.Setup(x => x.GetSubjects(1)).Returns(...);
    		
    		int rank = component.GetRank(1);
    		_studentServiceMock.VerifyAll();
    			
    		Assert.AreEqual(1, rank, "GetRank method fails");
    	}
    }	
