    public class AirplaneMetaData
    {
        [DataMember()]
        public virtual DataType propertyName;
    }
    [MetadataType(typeof(AirplaneMetaData))]
    public partial class Airplane
    {
        // blank partial class
    }
