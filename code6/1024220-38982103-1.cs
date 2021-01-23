    `IdentityResult` in this case does't have protected constructor but
    it has protected property `Succeeded` which can be accessed within
    class who inherited `IdentityResult`.
    
    We can achieve like in following example:
    
        public class IdentityResultMock : IdentityResult
        {
            public IdentityResultMock(bool succeeded = false)
            {
                this.Succeeded = succeeded;
            }
        }
    
        var result = new IdentityResultMock(true);
        Console.WriteLine(result.Succeeded);
    
        result.Succeeded // This is not allowed! Please use constructor.
