    public class MyViewModel: INotifyPropertyChanged
    {
       public string Caption {get;set;} //NotifyPropertyChanged() required.
    
       public string NumberOfDevices {get;set;} //NotifyPropertyChanged() required.
    
       private void GetNumberDevices()
       {
           int devices = 0;
           var result = CP210xWrapper.CP210x_GetNumDevices(ref devices);
           NumberOfDevices = string.Format("Number Of Devices:{0}", devices);
       }
       //INotifyPropertyChanged implementation omitted for brevity.
    }
