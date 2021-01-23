    public partial class CommonForm : Form
    {
        public CommonForm(MyTopScreen screen)
        {
            this.TopScreen = screen;
        }
        private MyTopScreen TopScreen{ get; set; }
    }
