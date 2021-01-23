    public class UnitTestContext
    {
    
       public Mock<IRepository> Repo {get;set;}
       
    
       public UnitTestContext()
       {
          // create suitable note / subversion objects 
          // either by passing them in or new-ing them up directly with default values. 
          Repo = new Mock<IRepository>();
          Repo.Setup(x => x.GetById<Note>(note.Id)).Returns(note);
          Repo.Setup(x => x.GetById<SubmissionVersion>(It.IsAny<Guid?>())).Returns(subVersion.Object);
    
       }
    }
