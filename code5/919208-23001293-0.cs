    public class SomeHandler : IHandler<SomeEvent>, IHandler<SomeOtherEvent>
    {
       public SomeHandler()
       {
          //whatever init code
       }
    
       public void Handle(SomeArgs args)
       {
           //Common code
       }
       
       public void Handle(SomeOtherArgs args)
       {
           //Common code
       }
    }
