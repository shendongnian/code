     [Test]
     public void ServiceLogicIsExecuted()
     {
         var collaborator = Substitute.For<ICollaborator>();
        
         //Tell the test double to return the Func's result. You'd probably want to do this in the setup method.
         collaborator.PerformServiceOperation(Arg.Any<Func<int>>()).Returns(x => ((Func<int>)x[0]).Invoke());
        
         var sut = new Service(collaborator);
        
         var result = sut.CalculateSomething();
        
         Assert.That(result, Is.EqualTo(99));
     }
        
     public class Service
     {
         private readonly ICollaborator _collaborator;
        
         public Service(ICollaborator collaborator)
         {
             _collaborator = collaborator;
         }
        
         public int CalculateSomething()
         {
             return _collaborator.PerformServiceOperation(ExecuteLogic);
         }
        
         private static int ExecuteLogic()
         {
             return 99;
         }
     }
        
     public interface ICollaborator
     {
         T PerformServiceOperation<T>(Func<T> func);
     }
