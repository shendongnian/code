    public class Foo
    {
        public DateTime DateTime { get; set; }
    }
...
    var json = "{\"DateTime\":\"2014-01-01T00:00:00.000Z\"}";
    var settings = new JsonSerializerSettings
                        {
                            DateTimeZoneHandling = DateTimeZoneHandling.Local
                        };
    var foo = JsonConvert.DeserializeObject<Foo>(json, settings);
    Debug.WriteLine("{0} ({1})", foo.DateTime, foo.DateTime.Kind);
