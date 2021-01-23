    public class VerifySomethingCodeAttribute : Attribute, IHasRequestFilter
    {
        IHasRequestFilter IHasRequestFilter.Copy()
        {
            return this;
        }
        public int Priority { get { return int.MinValue; } }
        public void RequestFilter(IRequest req, IResponse res, object requestDto)
        {
            SomethingRequest somethingRequestDto = requestDto as SomethingRequest;
            if(somethingRequestDto == null)
                return;
            // Verify the code
            // Replace with suitable logic
            // If you need the database your wire it up from the IoC
            // i.e. HostContext.TryResolve<IDbConnectionFactory>();
            bool isUnique = ...
            if(!isUnique)
                throw HttpError.Conflict("This record already exists");
        }
    }
