    public class Material
    {
        public decimal Density { get; set; }
    }
    
    public class BendingMaterial : Material
    {
        public string Bendability { get; set; }
    }
    
    public class OtherMaterial : Material
    {
        public bool IsOther { get; set; }
    }
