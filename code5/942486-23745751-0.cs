    public interface IEntity
    {
       object EntityID { get; set; }
    }
    public abstract class BaseEntity: IEntity
    {
       public abstract object EntityID { get; set; }
    }
    public class Campaign : BaseEntity
    {
       #region Properties
       public int ID { get; set; }
       public string Name { get; set; }
       public string CreatedBy { get; set; }
       public DateTime CreatedOnDate { get; set; }
       public virtual List<Fee> Fees { get; set; }
    
       #endregion
       #region BaseEntity Implementation
       public override object EntityID
       {
           get { return this.ID; }
       }
       #endregion   
       #region Constructors
       public Campaign()
       {
          this.CreatedOnDate = DateTime.Now;
          this.Fees = new List<Fee>();
       }
       #endregion
    }
    //View model
    //THIS is the class you want to validate
    public class CampaignViewModel
    {
       #region Properties
       public int ID { get; set; }
       [StringLength(50)]
       public string Name { get; set; }
       [Required]
       public string CreatedBy { get; set; }
       public DateTime CreatedOnDate { get; set; }
       public Fee AssociatedFee { get; set; } 
      
       #endregion
 
       #region Constructors
       public CampaignViewModel() 
       { }
       public CampaignViewModel(Campaign data)
       {
          this.ID = data.ID
          this.Name = data.Name;
          this.CreatedBy = data.CreatedBy;
          this.CreatedOn = data.CreatedOn;
          this.AssociatedFee = data.Fees.Where(x=>x.Active && x.ID == this.ID);
          //Just an example
       }
       #endregion
    }
