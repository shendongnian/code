    public class Rsvp
    {
        public string Response { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Rsvp(string response, DateTime createdDate)
        {
            Response = response;
            CreatedDate = createdDate;
        }
        public Rsvp WithResponse(string newResponse)
        {
            return new Rsvp(newResponse, this.CreatedDate);
        }
        public Rsvp WithCreatedDate(DateTime newCreatedDate)
        {
            return new Rsvp(this.Response, newCreatedDate);
        }
    }
