    public partial class MyUiClass
    {
        public MyUiClass()
        {
            this.Loaded += (sender, e) => { this.DataContext = new MyViewModelClass(); }
        }
    }
