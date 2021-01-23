    List<Panel> panels = new List<Panel>();
    panels.AddRange(new[]{PageMainScreen, PageNewRegistration, PageSelectedPatient});
    public void setMeVisible(string PanelName) {
      var c = panels.FirstOrDefault(panel=>panel.Name == PanelName);
      if(c != null) {
         c.Visible = true;
         if(currentShown != null) currentShown.Visible = false;
         currentShown = c;
      }      
    }
