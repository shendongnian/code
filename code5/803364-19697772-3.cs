    internal class MyClass
    {
        private ApiObject apiObject;
    
        internal MyClass()
        {
          InitializeAsync();
        }
    
        private async Task InitializeAsync()
        {
          apiObject = await CreateApiObjectAsync();
          // At this point the instance is created and fully initialized.
        }
    }
