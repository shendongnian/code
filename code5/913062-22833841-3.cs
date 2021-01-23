    public class Result : IResult
    {
        public object Value { get; set; }
    }
    public interface IResult
    {
        object Value { get; set; }
    }
