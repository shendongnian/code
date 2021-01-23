    public class Client
    {
        public int SelectedSexId { get; set; }
        public IList<Sex> SexList { get; set; }
        public IList<SelectListItem> SexListSelectListItems
        {
            get
            {
                SexList=SexList??new List<Sex>();
                var list = (from item in SexList
                            select new SelectListItem()
                            {
                                Text = item.Name,
                                Value = item.Id.ToString(CultureInfo.InvariantCulture)
                            }).ToList();
                return list;
            }
            set { }
        }
    }
