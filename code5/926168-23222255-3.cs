    var activities = (List<Activity>)listbox1.ItemsSource;
    var myObject = (Activity)listbox1.SelectedItem;
    activities.Remove(listbox1.SelectedItem);
    myObject.Date = DateTime.Now; //to provide your last request(add the current date)
    var activities2 = (List<Activity>)listbox2.ItemsSource;
    if(activities2 == null)
    { 
        activities2 = new List<Activity>(); 
        listbox2.ItemsSource = activities2;
    }
    activities2.Add(myObject);
