    public class ViewModel
    {
        public List<IceCreamFlavor> Flavors { get; set; }
        [Display(Name = "Favorite Flavor")]
        public int SelectedFlavorId { get; set; }
        public IEnumerable<SelectListItem> FlavorItems
        {
            get { return new SelectList(Flavors, "Id", "Name");}
        }
    }
