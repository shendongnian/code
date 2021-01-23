    public class MyViewModel
    {
       // declare the delegate signature...
       delegate void ScrollIntoViewDelegateSignature(EventManagementTemplate objEvent);
       
       // create a pointer to the delegate that can be set by the code behind...
       public ScrollIntoViewDelegateSignature ScrollIntoView {get; set;}
    
       protected AddRow()
       {
          .. your code here
          // call the delegate...
          if (ScrollIntoView != null)
             ScrollIntoView(objEvent)
       }
    }
    
    public class MyControlOrWindowThatContainsDataGrid : UserControl/ChildWindow/Page
    {
       public void Initialize()
       {
          ...your code here
          // set the scrollIntoView delegate...
          myViewModel.ScrollIntoView = ScrollIntoView;
       }
    
       // create a ScrollIntoView function
       // ==> the return value and parameters MUST match the delegate signature
       public void ScrollIntoView(EventManagementTemplate objEvent)
       {
          myDataGrid.ScrollIntoView(objEvent);
       }
    }
