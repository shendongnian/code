    public interface IHasAppId
    {
        public string AppId { get; set; }
    }
    public class RequestDto1 : IHasAppId { ... }
    public class RequestDto2 : IHasAppId { ... }
