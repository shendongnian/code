     public ActionNotes() {
          InitializeComponent();
          var x = this.WorkID.ToString();
          Dispatcher.InvokeAsync(() =>
          {
            MessageBox.Show(this.WorkID.ToString());
          });
    }
