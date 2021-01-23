    Public Class MyWindow()
    {
     public string Labeltext{get; set;}
    private void labelStstusUpdate(string message)
    {
        this.Labeltext = message
         this.NotifyOfPropertyChange(() => this.Labeltext );
    }
    }
