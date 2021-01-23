    public class GeoInfo
    {
        public int Id { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("PersonGeoInfo")]
        public int? PersonGeoInfoId { get; set; }
        public virtual GeoInfo PersonGeoInfo { get; set; }
    }
    public class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [ForeignKey("CarGeoInfo")]
        public int? CarGeoInfoId { get; set; }
        public virtual GeoInfo CarGeoInfo { get; set; }
    }
