      for (int i = 0; i < 5; i++) {
        // Mind the case: Button, not button
        Button b = new Button();
        // // Mind the case: Name, not name
        b.Name = i.ToString();
    
        //TODO: place your buttons somewhere:
        // on a panel
        //   myPanel.Controls.Add(b);
        // on a form
        //   this.Controls.Add(b);
        // etc.
        //TODO: it seems, that you want to add Click event, something like
        //  b.Click += MyButtonClick;  
      }
