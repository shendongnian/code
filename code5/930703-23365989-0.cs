    namespace MVCApplication
    {
    	[MetadataType(typeof(TutorMetaData))]//<- Just adding this class level attribute does the job for us.
    	public partial class Tutor
    	{
    		public Tutor()
    		{
    			this.Examinations = new HashSet<Examination>();
    		}
    
    		public decimal TutorID { get; set; }
    		public string FirstName { get; set; }
    		public string LastName { get; set; }
    		public string Address1 { get; set; }
    		public string Address2 { get; set; }
    		public string Address3 { get; set; }
    		public string Tel1 { get; set; }
    		public string Tel2 { get; set; }
    		public string EMail { get; set; }
    		public string Password { get; set; }
    		public Nullable<bool> IsConfirmed { get; set; }
    
    		public virtual ICollection<Examination> Examinations { get; set; }
    	}
    	
    	public class TutorMetaData
    	{
    		public Tutor()
    		{
    			this.Examinations = new HashSet<Examination>();
    		}
    
    		public decimal TutorID { get; set; }
    		[Required] //<-- use as many annotations as you like
    		public string FirstName { get; set; }
    		[Required] //<-- use as many annotations as you like
    		public string LastName { get; set; }
    		public string Address1 { get; set; }
    		public string Address2 { get; set; }
    		public string Address3 { get; set; }
    		public string Tel1 { get; set; }
    		public string Tel2 { get; set; }
    		public string EMail { get; set; }
    		public string Password { get; set; }
    		public Nullable<bool> IsConfirmed { get; set; }
    
    		public virtual ICollection<Examination> Examinations { get; set; }
    	}
    }
