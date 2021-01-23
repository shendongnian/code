    public interface ICustomerService 
    {
        BaseResponse DoSomething(BaseRequest request);
    }
    
    public abstract class BaseResponse 
    {
        public bool IsSuccess { get; set; }
        public IList<string> Errors { get; set; }
    }
    
    /*
    Note: BaseResponse & BaseRequest, follow the command pattern for passing information you would impliment concrete versions of these.
    */
