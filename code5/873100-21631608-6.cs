    public class SponsorViewModel { 
        public String CoSponsorName { get; set; }
        public String CosponserEmail { get; set; }
        ...
    }
    public class SponsorsEditViewModel {
        public ICollection<SponsorViewModel> Sponsors { get; set; }
        ...
    }
