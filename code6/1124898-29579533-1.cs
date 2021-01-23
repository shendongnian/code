    [Serializable]
    public class MyClass 
    {
        [XmlArrayItem("event", IsNullable = false)]
        public LivescoreLeagueMatchEventsEvent[] events { get; set; }
    }
