    public void setMeVisible(string PanelName) {
      PageMainScreen.Visible = false;
      PageNewRegistration.Visible = false;
      PageSelectedPatient.Visible = false;
      Control c = sameContainer.Controls[PanelName];
      if(c != null) c.Visible = true;
    }
