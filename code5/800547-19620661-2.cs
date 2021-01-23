    public class PaxDescriptor : IQueryPartDescriptor
    {
        public string ObjectToQueryPart(string prefix, object obj)
        {
            var pax = (Pax)obj;
            var queryPart = prefix + "[paxType]=" + pax.PaxType;
            if (pax.PaxType == PaxType.Child)
            {
                queryPart += prefix + "[age]=" + pax.Age;
            }
            return queryPart;
        }
        public IEnumerable<ChildrenCollectionDescriptor> ChildrenListsDescriptors
        {
            get { return Enumerable.Empty<ChildrenCollectionDescriptor>(); }
        }
    }
    public class RoomDescriptor : IQueryPartDescriptor
    {
        public string ObjectToQueryPart(string prefix, object obj)
        {
            return String.Empty;
        }
        public IEnumerable<ChildrenCollectionDescriptor> ChildrenListsDescriptors
        {
            get
            {
                return new[]
                {
                    new ChildrenCollectionDescriptor(
                        room => ((Room)room).Paxes,
                        (index, roomsPrefix) => roomsPrefix + "[" + index + "]")
                };
            }
        }
    }
    public class AvaliableHotelRequestDescriptor : IQueryPartDescriptor
    {
        public string ObjectToQueryPart(string prefix, object obj)
        {
            var request = (AvaliableHotelRequest)obj;
            return
                "method=" + request.Method + "&" +
                "apiKey=" + request.ApiKey + "&" +
                "destinationID=" + request.DestinationId + "&" +
                "checkIn=" + request.CheckIn.ToString("yyyy-MM-dd") + "&" +
                "checkOut=" + request.CheckOut.ToString("yyyy-MM-dd") + "&" +
                "currency=" + request.Currency + "&" +
                "clientNationality=" + request.ClientNationality + "&" +
                "onRequest=" + request.OnRequest.ToString().ToLower();
        }
        public IEnumerable<ChildrenCollectionDescriptor> ChildrenListsDescriptors
        {
            get
            {
                return new[]
                {
                    new ChildrenCollectionDescriptor(
                        request => ((AvaliableHotelRequest)request).Rooms,
                        (index, _) => "&rooms[" + index + "]")
                };
            }
        }
    }
