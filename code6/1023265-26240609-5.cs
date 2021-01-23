    public class ViewModel : ViewModelBase, INotifyDataErrorInfo
        { 
          public void CallAngularMethod()
          {
               HtmlPage.Window.Invoke("callAngularFunc", new[] { "Testing" });
          }
        }
