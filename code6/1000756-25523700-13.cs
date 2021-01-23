    public class WizardViewModel : INotifyPropertyChanged
    {
         // OnPropertyChanged(String) and PropertyChanged event
         public String Text
         {
             get //..
             set
             {
                  this._Text = value;
                  Validate();
                  this.OnPropertyChanged("SelectedItem")
             }
         }
    
         
         public Object SelectedItem
         {
             get //..
             set
             {
                  this._SelectedItem = value;
                  Validate();
                  this.OnPropertyChanged("SelectedItem")
             }
         }
    
         public bool IsValid { // ...}
       
         private void Validate()
         {
             if (String.IsNullOrEmpty(this._Text))
                 this.IsValid = false;
             // ....
          }
    }
