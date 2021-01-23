    public class BTLogFrontEndViewModel : ViewModelBase
    {
        private ObservableCollection<OutputTapeViewModel> m_SelectedOutputtapeList;
        public ObservableCollection<OutputTapeViewModel> SelectedOutputtapeList
        {
            get
            {
                return m_SelectedOutputtapeList;
            }
            set
            {
               m_SelectedOutputtapeList = value;
              
               NotifyPropertyChanged("SelectedOutputtapeList");
            }
        }
    }
