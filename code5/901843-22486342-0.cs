    [Table("VociRicevuta")]
    public partial class VoceRicevuta
    {
    [Key]
    public virtual Prestazione { get; set; }
    [...]
   
    public long? IdPrestazione { get; set; }
    [...]
    public virtual Prestazione Prestazione { get; set; }
    }
    [Table("Prestazioni")]
    public partial class Prestazione
    {
    [Key]
    public long Id { get; set; }
    [...]
    [InverseProperty("Prestazione")]
    public virtual VoceRicevuta VoceRicevuta { get; set; }
    }
