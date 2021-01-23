    namespace TCS.Proxy
    {
        class PermissionProxy
        {
             public void SomeFunction()
             {
                 int operationId = 0;
                 var exp = ((Expression<Func<UserDetailInfo, bool>>) (x => x.OperationID == operationId)).ToString()
             }
        }
    }
