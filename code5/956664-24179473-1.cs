    public class SuggestionViewModel
    {
        public bool PADP { get; set; }
        public bool PremedicationPADP { get; set; }
        public string NbPADP { get; set; } //*1
        public IEnumerable<SelectListItem> PADPItems { get; set; }
        public bool Other { get; set; }
        public SuggestionViewModel()
        {
             PADPItems = (new double[] { 0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5, 2.75, 3, 3.25, 3.5, 3.75, 4 }).Select(d => new SelectListItem { Value = d.ToString(), Text = d.ToString() });
             PADCItems = (new double[] { 0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5, 2.75, 3, 3.25, 3.5, 3.75, 4 }).Select(d => new SelectListItem { Value = d.ToString(), Text = d.ToString() });
        }
    }
