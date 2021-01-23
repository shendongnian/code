    public class Venue : BaseObject, IBaseObject
    {
    [Required]
    public virtual User Owner { get; set; }
    [Required]
    [MaxLength(40)]
    public string Name { get; set; }
    [ForeignKey("RegionId")]
    [DisplayName("Region")]
    [Required]
    public virtual int RegionId { get; set; } // cant see baseObject so I just assume int
    [ForeignKey("CountryId")]
    [DisplayName("Country")]
    [Required]
    public int  CountryId { get; set; }
   
    // nav props
    public virtual StandingData Region { get; set; }
    public virtual StandingData Country { get; set; }
    }
