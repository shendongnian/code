    public class SomeViewModel
    {
        public static readonly Expression<Func<SomeEntity, SomeViewModel>> Map = (o) => new SomeViewModel
        {
            id = o.id,
            name = o.name
        }
        
        public int id { get; set; }
        public string name { get; set; }
    }
    // Somewhere in your controller
    var mappedAddresses = Addresses.Select(SomeViewModel.Map);
