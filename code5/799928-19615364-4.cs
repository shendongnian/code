    public class UnitTestContext
    {
    
       public Mock<IRepository> Repo {get;set;}
       
    
       public UnitTestContext()
       {
          // create suitable note / subversion objects 
          // either by passing them in or new-ing them up directly with default values. 
          repo = new Mock<IRepository>();
          repo.Setup(x => x.GetById<Note>(note.Id)).Returns(note);
          repo.Setup(x => x.GetById<SubmissionVersion>(It.IsAny<Guid?>())).Returns(subVersion.Object);
    
       }
    }
