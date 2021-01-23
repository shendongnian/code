    Control currentShown;
    public void setMeVisible(string PanelName) {
      Control c = sameContainer.Controls[PanelName];
      if(c != null) {
         c.Visible = true;
         if(currentShown != null) currentShown.Visible = false;
         currentShown = c;
      }
    }
