    public class Student{
          public Student()
          {
              BatchSelectList = new List<SelectListItem>();
              BatchSelectList.Add(new SelectListItem { Text = "Some Label", Value = "Some Val" };
          }
          public Batch batch {get;set;}
          public string Name{get;set;}
          public string CNIC {get;set;}
          
          //Drop down properties used in view
          public String BatchSelectedItem { get; set; }
          public List<SelectListItem> BatchSelectList { get; set; }
    }
