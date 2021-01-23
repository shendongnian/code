      private void CreateEventList()
      {
         events = ExtractData();
         eventComboBox.Items.Clear();
         string eventTrue = ("-Events-");
         string descriptTrue = ("Pick an event");
         string eventFalse = ("-No Event-");
         string descriptFalse = ("-No events today-");
         if ( !events.Any( e => e.Day == monthCalender ) )
         {
           // no occurrences
           eventComboBox.Items.Insert(0, eventFalse);
         } 
         else
         {
           // there are some occurrences
           eventComboBox.Items.Add(eventTrue);
           foreach (communityEvent e in events)
           {
            if (monthCalender == e.Day)
            {
               eventComboBox.Items.Add(e.GetName());
            }
           }
         }
