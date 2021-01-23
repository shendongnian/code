    namespace TCS.Proxy
    {
        public class PermissionProxy
        {
             private class c__DisplayClass5
             {
                 public int operationId;
             }
             public void SomeFunction()
             {
                 int operationId = 0;
                 
                 var <>c__DisplayClass5 = new c__DisplayClass5();
                 <>c__DisplayClass5.operationId = operationId;
                 var exp = ((Expression<Func<UserDetailInfo, bool>>) (x => x.OperationID == <>c__DisplayClass5.operationId)).ToString()
             }
        }
    }
