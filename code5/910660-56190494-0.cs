    public class SampleClass
    {
        [JsonProperty("sampleEnum")] public string sampleEnumString;
        [JsonIgnore]
        public SampleEnum sampleEnum
        {
            get
            {
                if (Enum.TryParse<SampleEnum>(sampleEnumString, true, out var result))
                {
                    return result;
                }
                return SampleEnum.UNKNOWN;
            }
        }
    }
    public enum SampleEnum
    {
        UNKNOWN,
        V1,
        V2,
        V3
    }
