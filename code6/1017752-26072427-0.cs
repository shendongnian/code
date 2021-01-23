    public class PersonViewModel
    {
        public PersonViewModel()
        {
            this.PopulateApplicationStatusList();
        }
        public SelectList ApplicationStatusList { get; set; }
        public void PopulateApplicationStatusList()
        {
            List<SelectListItem> applicationStatusItems = new List<SelectListItem>();
            applicationStatusItems.Add(new SelectListItem { Value = "1", Text = "Application Accepted" });
            applicationStatusItems.Add(new SelectListItem { Value = "0", Text = "Application Rejected" });
            this.ApplicationStatusList = new SelectList(applicationStatusItems, "Value", "Text", null);
        }
    }
