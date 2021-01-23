    public class MainViewModel
    {
        public void AddValue()
        {
            var propVal = App.Current.MainWindow.Resources["propertVal"] as PropertVal; 
            if (propVal == null)
                return;
            propVal.AddListItem("Some New Item");
        }
    }
