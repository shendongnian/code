    public class SomeViewModel
    {
        private SomeViewModel() 
        { }
    
        public static async Task<SomeViewModel> Create()
        {
            SomeViewModel model = new SomeViewModel();
            await model.LoadData();
            return model;
        }
    
        public async Task LoadData()
        {
            UIData = await Task.Run(() => SomeService.SelectAllUIData());
        }
    
        //...
    }
