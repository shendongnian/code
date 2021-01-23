    public YourViewModel GetMethodName(int id)
    {
      var vm = new YourViewModel();
      
      var _brand = TenantManager.GetType(Request.RequestUri);
      var _settings = new SettingsService(_brand);
      
      vm.GroupUsers = UserApi().GetUsers(id);
      vm.someIntValue = _settings.GetValueAsInt(UserSettings, 13);
      
      return vm;
    }
