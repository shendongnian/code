        private HostSystemInformation selectedSystemInformation;
        public HostSystemInformation SelectedSystemInformation
        {
            get { return selectedSystemInformation; }
            set { SetProperty(ref selectedSystemInformation, value); }
        }
       
        public UserBase_ViewModal()
        {
            deleteIp = new DelegateCommand(DeleteSystemInformationInIpTable);
        }
        private void DeleteSystemInformationInIpTable()
        {
           SystemInformation.Remove(SelectedSystemInformation);
        }
