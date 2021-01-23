     public partial class MainWindow : Window
     {
      int Value=0;
      private delegate void UpdateMyLabel(System.Windows.DependencyProperty dp, Object value);
      private void Processmerge()
      {
         UpdateMyLabel updateLabelDelegate = new UpdateMyLabel(_Mylabel.SetValue);
         foreach (var item in Collections)
         {
                string _Mylabel= "Process completed..." + Value.ToString() + " %";
                Dispatcher.Invoke(updateLabelDelegate, System.Windows.Threading.DispatcherPriority.Background, new object[] { System.Windows.Controls.Label.ContentProperty, _Mylabel});
 
           Value++;
         }
      }
    }
    }
