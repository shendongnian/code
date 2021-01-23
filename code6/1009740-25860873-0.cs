    public override void FeatureActivated(SPFeatureReceiverProperties properties) 
    { 
        SPWeb oWeb = (SPWeb)properties.Feature.Parent;    
        SPList list=oWeb.List["ListNameorDocLibName"];
        list.EventReceivers.Add(_theeventRecieverType, Assembly.GetExecutingAssembly           ().FullName, "EventReceiverProject1.EventReceiver1.EventReceiver1");
        list.Update();
    }
