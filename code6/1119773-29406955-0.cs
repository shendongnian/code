    public class MyViewModel
    {
        public SelectList MySelectList{ get; set; }
        public List<string> SelectedValues { get; set; }
        public string SelectedString
        {
            get
            {
                if (SelectedValues == null) return "";
                return string.Join(",", SelectedValues);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    SelectedValues = value.Split(',').ToList();
                }
            }
        }
    }
