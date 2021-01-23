    using Microsoft.Practices.ServiceLocation;
    public class GetData {
        DataFromADVM _data;
        public GetData() {
            _data = ServiceLocator.Current.GetInstance<DataFromADVM>();
        }
    }
