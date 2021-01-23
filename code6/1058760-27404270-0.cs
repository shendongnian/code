    System.Action method = () =>
    {
         OrganizationsVM = new OrganizationsVM(this.Organizations);
         DialogService.Instance.ShowDialog(OranizationsVM);                
    };
    
    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(method);       
 
