    public class ViewModel 
    {
         private ObservableCollection<ResultView> _results;
         public ObservableCollection<ResultView> Results
         {
            get { 
            if(_results == null)
            { 
              _results = new ObservableCollection<ResultView>() { new ResultView() { From = "Sample 1" } };
            }  
             return _results; 
            }
         }
    }
