    public class urunler : ICloneable 
    { 
    public int id { get; set; } 
    public string ismi { get; set; } 
    public string icerik { get; set; }
     public object Clone()
        {
            return this.MemberwiseClone();
        } 
    
    }
