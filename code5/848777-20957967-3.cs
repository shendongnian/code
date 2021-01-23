    class ModalPanel : Panel
    {
      public event EventHandler PanelHidden;
    
      protected override void OnVisibleChanged(EventArgs e)
      {
          base.OnVisibleChanged(e);
          var isHidden = this.Visible;
          if (isHidden)
              OnPanelHidden();
      }
      protected virtual void OnPanelHidden()
      {
         var handler = this.PanelHidden; 
        
         if(handler != null)
           handler(this, EventArgs.Empty);
      }
    }
