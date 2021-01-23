     public class Zoeken
        {
            public Zoeken() { Systemen = new List<CheckboxSysteem>(); }
            public List<VW_Checks> VwChecks { get; set; }
            public List<CheckboxSysteem> Systemen { get; set; }
        }
    
        public class CheckboxSysteem
        {
            public string Systeemnaam { get; set; }
            public bool isSelected { get; set; }
        }
