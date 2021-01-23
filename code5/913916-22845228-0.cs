    public class MyViewModel
    {
      public MyModel m;
      public void MyViewModel(MyModel m){this.m=m;}
      public string ActualIMageUrl
      {
        get
        {
           return "public/Images/"+m.RoleId+".jpg";
        }
      }
    }
