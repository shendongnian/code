    public class PartModel
    {
        public PartModel(TableRow row)
        {
            PartNumber = row.Field<string>("HardwareType");
            Number = row.Field<string> ("HardwareSerialNo");
        }
        public string PartNumber { get; set; }
        public string Number { get; set; }
    }
