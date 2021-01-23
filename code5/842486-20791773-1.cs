    public class View : Form
    {
        public Button DoStuffButton { get; set; }
        
        public void Bind(ViewModel vm)
        {
            DoStuffButton.DataBindings.Add("Enabled", vm, "IsDoStuffButtonEnabled");
        }
    }
