    public interface IRecord {
        int Counter { get; set; }
        int Pressure { get; set; }
    }
    public class GasConsumRecord : IRecord {
        public int Counter { get; set; }
        public int Pressure { get; set; }
    }
    public class AirConsumRecord : IRecord {
        public int Counter { get; set; }
        public int Pressure { get; set; }
    }
    private Double CalculateConsumption<T>(List<T> records)
        where T : IRecord
    {
        foreach (IRecord record in records){
            var x = record.Counter;
            var y = record.Pressure;
        }
    }
