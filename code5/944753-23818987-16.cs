       public class MyPageClass
        {
           private IDataRepository _repository; //not read-only
           public MyPageClass()
           {
              _repository = new RealDataRepository();
           }
           
           //here is the compromise; this method also returns the original repository so you can restore it if for some reason you need to during a test method.
           public IDataRepository SetTestRepo(IDataRepository testRepo)
           {
              _repository = testRepo;
           }
        }
   
