    namespace Stackoverflow
    {
       using System;
       using System.Windows;
       using System.Windows.Controls;
       public partial class MyBusyIndicator : UserControl
       {
          public MyBusyIndicator()
          {
             this.InitializeComponent();
          }
          public void ShowIndicator(bool isBusy)
          {
             this.myBusyIndicator.IsBusy = isBusy;
          }
        }
    }
