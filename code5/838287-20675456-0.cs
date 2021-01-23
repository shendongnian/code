    //Get the field EVENT_SELECTEDINDEXCHANGED
    var eventSelectedIndexChangedKey = typeof(ComboBox).GetField("EVENT_SELECTEDINDEXCHANGED", 
                                       System.Reflection.BindingFlags.NonPublic |
                                       System.Reflection.BindingFlags.Static)
                                      .GetValue(comboBox1);
    //Get the event handler list of the comboBox1
    var eventList = typeof(ComboBox).GetProperty("Events",
                                     System.Reflection.BindingFlags.NonPublic | 
                                     System.Reflection.BindingFlags.Instance)
                                    .GetValue(comboBox1, null) as EventHandlerList;
    //check if there is not any handler for SelectedIndexChanged
    if(eventList[eventSelectedIndexChangedKey] == null){
        //....
    } else {
        //....
    }
