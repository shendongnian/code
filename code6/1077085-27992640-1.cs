    public class ErrorBase : IError
    {
         public DateTime GETDATE { get; set; }
         //...ditto all the other IError properties
    }
    public interface IHaveError
    {
        ErrorBase Error { get; set; }
    }
    public class Business : IHaveError
    {
        public ErrorBase { get; set; }
    }
