    public class DialogViewModel
    {
        public IEnumerable<string> Data { get; private set; }
    
        public bool HasErrored { get; private set; }
    
        public string ErrorMessage { get; private set; }
    
        async public static Task<DialogViewModel> BuildViewModelAsync()
        {
            try
            {
                var data = await GetDataCollection();
                return new DialogViewModel(data);
            }
            catch (Exception)
            {
                return new DialogViewModel("Failed!");
            }
        }
    
        private DialogViewModel(IEnumerable<string> data)
        {
            Data = data;
        }
    
        private DialogViewModel(string errorMessage)
        {
            HasErrored = true;
            ErrorMessage = errorMessage;
        }
            
        private async static Task<IEnumerable<string>> GetDataCollection()
        {
            // do something async...
            return await Task.Factory.StartNew(() => new List<string>()
            {
                "John",
                "Jack",
                "Steve"
            });
        }
    }
