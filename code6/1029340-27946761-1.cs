    // using Windows.ApplicationModel.Core;
    // in an async method:
	Contact user = null;
	AutoResetEvent resetEvent = new AutoResetEvent(false);
	await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
		CoreDispatcherPriority.Normal, 
		(async ()=>{
		  ContactPicker contactPicker = new ContactPicker();
		  contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
		  user = await contactPicker.PickContactAsync();
		  resetEvent.Set();
		}
	);
	resetEvent.WaitOne();
    if (user != null) {
        // do smth
    }
