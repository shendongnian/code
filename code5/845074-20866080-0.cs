      public void MouseClick(object sender, EventArgs e)
      {
          var panel = sender as Panel;
          if(panel == null) // check if the sender is a panel
               return;
          string senderName = panel.Name;
          Panel clickedPanel = formsPanels[senderName];
          // Your Code
      }
