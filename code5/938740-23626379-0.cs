    public class RequestModel
    {
        public IList<Request> Requests { get; set; }
        public IList<RequestStatusModel> RequestStatus { get; set; }
        public IEnumerable<RequestStatusModel> FilteredRequestStatus
        {
            get
            {
                return RequestStatus.Where(rs => Requests.Select(r => r.RequestID).Contains(rs.RequestID));
            }
        }
    }
