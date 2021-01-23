    public class DeliveryDriver
    {
        public int DriverID { get; set; }
        public string DriverName { get; set; }
    }
    ...
    foreach (DataRow dr in dsDriverID.Tables[0].Rows)
    {
        IDeliveryDriver.Add(new DeliveryDriver
        {
            DriverID = (int) dr["DriverId"],
            DriverName = (string) dr["DriverName"]
        });
    }
