    public class CreateCustomerVM
    {
       public string MidName{ get; set; }
       [Required]
       public string FirstName{ get; set; }
       public string Surname{ get; set; }
       public List<SelectListItem> MidNames { set;get;}
       public CreateCustomerVM()
       {
         MidNames=new List<SelectListItem>();
       }
    }
