    public class DeviceEditViewModel
    {
        public Device dev { get; set; }
        public IEnumerable<SelectListItem> Manufactors { get; set; }
        public int? SelectedCategory { set; get; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
    }
