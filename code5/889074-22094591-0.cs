    public class Vuln : VulnSmall {
      public virtual List<VulnerabilityReference> VulnerabilityReferences { get; set; }    
      public Vuln(){
        VulnerabilityReferences = new List<VulnerabilityReference>();
      }
    }
