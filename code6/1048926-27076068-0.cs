     public ICommand RunHyperlink {
         get {
             return new ActionCommand(this.ButtonClick);
         }
     }
     
     private void ButtonClick() {
            Process.Start(new ProcessStartInfo(this.Link));
     }
