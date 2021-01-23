    public class MyPopupWindow
    {
     public int MyClassID{get;set;}
     public List<OtherClass> OtherClasses {get;set;}
     public MyPopupWindow(){//default constructor}
     public MyPopupWindow(int myClassID)
     {
      //A function to call all other classes LINQ example
      OtherClasses = (from m in #db.OtherClass#
              where m.MyClassID = myClassID
              select m).ToList();
      OtherDataGrid.DataSource = OtherClasses;
      
     }
    }
