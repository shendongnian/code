      public delegate void LinkButtonClickHandler (object sender,  EventArgs data);
    
      // The event
      public event LinkButtonClickHandler LinkButtonClicked;
    
      // The method which fires the Event
      protected void OnLinkButtonClick (object sender,  EventArgs data)
      {
          // Check if there are any Subscribers
          if (LinkButtonClicked!= null)
          {
              // Call the Event
              LinkButtonClicked(this, data);
          }
      }
