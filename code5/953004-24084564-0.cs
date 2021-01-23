    public class MyDataGrid : DataGrid
    {
       // publicly available to change anywhere...
       public string AnyProperty { get; set; }
    
       // some property that is publicly readable, yet protected, such as internal
       // control to the class
       public string SomeProperty { get; protected set; }
    
    
       public MyDataGrid()
       {
          // have a default hook to some general functionality you want to perform
          MouseDoubleClick += MyDataGridMouseDoubleClick;
       }
    
       // make protected and virtual so you CAN override this in a subclass
       protected virtual void MyDataGridMouseDoubleClick(object sender, MouseButtonEventArgs e)
       {
           // anything you want to do commonly for a double-click...
       }
       protected void SomeOtherFeature()
       { // do something based on some settings? 
       }
    }
    
    public class MySubclassDataGrid : MyDataGrid
    {
       public int SomeNewProperty { get; set; }
    
       public MySubclassDataGrid()
       {
       }
    
       protected override void MyDataGridMouseDoubleClick(object sender, MouseButtonEventArgs e)
       {
          // anything DIFFERENT for handling in the data grid instance...
       }
    
    }
