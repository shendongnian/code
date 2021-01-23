        public class LocationViewModel<TDetailsData>
        {
            public Guid Id { get; set; }
            // multiple different properties here.
  
            public string Type { get; set; }
            public TDetailsData DetailsData { get; set; }
        }
