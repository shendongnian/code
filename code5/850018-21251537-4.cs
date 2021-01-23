    using System.Text;
    using System.Threading.Tasks;
    using InSync.appseconnect.Helper;
    using ObjectDAL;
    using jsonorm;
    public class DataContext : ObservableObjectGeneric<DataContext>
    {
        private List<Task_details> _taskdetaillist;
        public DataContext()
        {
            Followers = new Task_details().GetElementList("Task_details");
        }
        public List<Task_details> Followers
        {
            get
            {
                return _taskdetaillist;
            }
            set
            {
                _taskdetaillist = value;
                OnPropertyChanged("Followers");
            }
        }
    }
