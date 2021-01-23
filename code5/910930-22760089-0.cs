    public interface IRequestValidator {
        bool Validate(IRequest req);
    }
    
    // at first you have one way of validating elements
    public class AllWelcomeValidator: IRequestValidator {
        public bool Validate(IRequest req) {return true; // no validation atm }
    }
    
    // later...
    
    public class NowWeGotRulesValidator: IRequestValidator {
        public bool Validate(IRequest req) {
            if (string.IsNullOrWhiteSpace(request.ClientId))
                throw new BusinessServiceException(ErrorType.InvalidRequest, "ClientId can not be null or Empty");
            // etc...
        }
    }
