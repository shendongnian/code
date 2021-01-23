    public class PersonSearchVM
    {
      public string SelectedGender { set;get;}
      public List<SelectListItem> Genders { set;get;}
      public List<Person> Results { set;get;}
    
      public PersonSearchVM()
      {
         Genders=new List<SelectListItem>();
         Results =new List<Person>();
      }
    }
