    public class Vuln : VulnSmall
    {
        public virtual List<VulnerabilityReference> VulnerabilityReferences { get; set; } 
    
        public Vuln()
        {
            this.VulnerabilityReferences = new List<VulnerabilityReference>();
        }
    }
