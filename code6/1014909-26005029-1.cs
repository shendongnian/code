    [MetaDataType(typeof(grid))]
    public partial class DataGrid
    {
    }
    public class grid:INotifyPropertyChanged
    {
        private bool? m_IsChecked;
        public Nullable<bool> IsChecked  
        get
        {
            return m_IsChecked;
        }
        set
        {
            if(m_IsChecked != value)
            {
                m_IsChecked=value;
                OnPropertyChanged("IsChecked");
            }
        }
    }
