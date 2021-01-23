    public class DemoPoco
    {
        public ObjectState MyObjectState { get; set; }
    }
    public static void Main( string[] args )
    {
        DemoPoco demo = new DemoPoco { MyObjectState = ObjectState.Active };
        
        var json = JsonConvert.SerializeObject( demo );
        Console.WriteLine(json); // output: {"MyObjectState":"is-active"}
    }
