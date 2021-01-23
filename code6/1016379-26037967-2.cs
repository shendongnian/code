    public class OutputTapeViewModel : ViewModelBase
    {
        private string m_Description;
    
        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
    
                NotifyPropertyChanged("Description");
            }
        }
    
        private bool m_IsSelected;
    
        public string IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                m_IsSelected = value;
    
                NotifyPropertyChanged("IsSelected");
            }
        }
    }
