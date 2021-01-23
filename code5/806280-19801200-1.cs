    SaveContactTask saveContactTask = new SaveContactTask();
    saveContactTask.Completed += new EventHandler<SaveContactResult>(saveContactTask_Completed);
    saveContactTask.FirstName = "John"; // card.PropertyFromvCard and so on...
    saveContactTask.LastName = "Doe";
    saveContactTask.MobilePhone = "2065550123";
    saveContactTask.Show();
