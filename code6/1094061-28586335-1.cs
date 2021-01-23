    [CollectionDataContract(Name="Data", Namespace="")]
    public class SeriesList : List<Series>
    {
    }
    [DataContract(Namespace = "")]
    public class Series
    {
        [DataMember(Name = "seriesid", Order=0)]
        public string SeriesId { get; set; }
        [DataMember(Name = "SeriesName", Order=1)]
        public string SeriesName { get; set; }
    }
