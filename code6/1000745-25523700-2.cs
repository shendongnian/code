    public class WizardModel : INotifyPropertyChanged
    {
         public String Text
         {
             get //..
             set
             {
                  this._Text = value;
                  Validate();
             }
         }
    
         
         public Object SelectedItem
         {
             get //..
             set
             {
                  this._SelectedItem = value;
                  Validate();
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
