    //String message
    Messenger.Default.Send(new NotificationMessage("SetupMyProductDefinitionVm"));
    //Custom typed message sent to ViewModel of specific type
    var myMsg = new MyMessageType();
    Messenger.Default.Send<MyMessageType, ProductDefinitionVm>(myMsg);
