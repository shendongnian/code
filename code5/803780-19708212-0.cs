    namespace Example.SampleResponse1JsonTypes
    {
    
        internal class FenwayRoom
        {
    
            [JsonProperty("url")]
            public string Url { get; set; }
    
            [JsonProperty("price")]
            public double Price { get; set; }
    
            [JsonProperty("room_code")]
            public string RoomCode { get; set; }
        }
    
        internal class RoomTypes
        {
    
            [JsonProperty("Fenway Room")]
            public FenwayRoom FenwayRoom { get; set; }
        }
    
        internal class Hotel
        {
    
            [JsonProperty("hotel_id")]
            public int HotelId { get; set; }
    
            [JsonProperty("room_types")]
            public RoomTypes RoomTypes { get; set; }
        }
    
    }
    
    namespace Example
    {
    
        internal class SampleResponse1
        {
    
            [JsonProperty("api_version")]
            public int ApiVersion { get; set; }
    
            [JsonProperty("hotel_ids")]
            public int[] HotelIds { get; set; }
    
            [JsonProperty("hotels")]
            public Hotel[] Hotels { get; set; }
        }
    
    }
