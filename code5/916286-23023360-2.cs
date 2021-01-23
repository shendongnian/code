    [ServiceContract]
    public interface IEventTypesService
    {
        [OperationContract]
        [WebGet(UriTemplate = "", ResponseFormat=WebMessageFormat.Json)]
        IList<EventType> GetEventTypes();
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        EventType GetEventType(string id);
    }
    [ServiceContract]
    public interface IEventsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        Stream GetEventsAsStream();
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Event GetEvent(string id);
    }
    public class EventsService: IEventsService, IEventTypesService
    {
         public IList<EventType> GetEventTypes() { //code in here }
         public EventType GetEventType(string id) { //code in here }
         public Stream GetEventsAsStream() { // code in here }
         public EventType GetEventType(string id) { // code in here }
    }
