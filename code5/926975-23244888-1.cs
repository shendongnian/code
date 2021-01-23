    public class RolesViewModel : BaseViewModel
    {
        private Collection<BO.RoleBO> roles;
        private BO.RoleBO selectedItem;
        public BO.RoleBO SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                NotifyOnPropertyChanged("SelectedItem"); 
            }
        }
        public Collection<BO.RoleBO> Roles
        {
            get { return roles; }
            set { roles = value; NotifyOnPropertyChanged("Roles"); }
        }
    }
