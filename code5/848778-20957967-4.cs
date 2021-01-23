    void ShowModalPanel()
    {
      var panel = new ModalPanel();
      panel.PanelHidden += delegate { PanelWasHidden(); }
    
      panel.Dock = DockStyle.Fill;
    }
    
    void PanelWasHidden()
    {
      // This will be called once the panel is hidden.
    }
