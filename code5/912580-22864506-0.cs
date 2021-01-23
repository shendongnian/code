    if (IsPostBack) {
      Panel p = createLanguagePanels();
      Panel1.Controls.Clear();
      Panel1.Controls.Add(p);
    }
    else {
      createLanguageSelectionList();
        
      Panel p = createLanguagePanels();
      Panel1.Controls.Clear();
      Panel1.Controls.Add(p);
    }
    
