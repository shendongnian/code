    public class UserDeviceViewModel
    {
        public int UserID { get; set; }
        public string CodeName { get; set; }
        public int DeviceID { get; set; }
        public IList<SelectListItem> Devices { get; set; }
    }
