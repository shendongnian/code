    namespace Stackoverflow
    {
       using System;
       public partial class MyBusyIndicator : UserControl
       {
          public void ShowIndicator(bool isBusy)
          {
             this.myBusyIndicator.IsBusy = isBusy;
          }
        }
    }
