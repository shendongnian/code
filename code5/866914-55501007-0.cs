    public class Agent
    {
            [JsonConverter(typeof(SizeJsonConverter))]
            public Size size = new Size();
            public long time_observed = 0;
    }
