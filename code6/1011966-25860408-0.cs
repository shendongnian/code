    public class MainModel
    {
        public async void LoadData()
        {
            var data = await Foo.GetBalance();
        }
    }
