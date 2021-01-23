       private bool enableFromOtherForm;
       public bool EnableFromOtherForm
       { 
          get { return enableFromOtherForm; }
         set { this.controlToChange.IsEnabled = value; }
       }
