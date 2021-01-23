    public async Task TestNavigationAsync()
    {
         var vm = new MyClass();
         await vm.InitializeAsync();
         vm.Jobs.Add(new JobVM(new JobModel()));
         vm.SelectJobCommand.Execute(null);       
     
         Assert.AreEqual(NavigationKeys.WizardJob,
                                      navigationService.CurrentPageKey); 
     }
