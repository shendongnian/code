    abstract class AppBase
    {
        protected abstract void OnStart();
    }
    class App: AppBase
    {
        public static async Task GetData() { await Task.Delay(1); }
        protected override async void OnStart()
        {
            await GetData(); 
        }
    }
