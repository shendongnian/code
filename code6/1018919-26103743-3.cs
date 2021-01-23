    public partial class MyView : Form, IMyView
    {
        private MyModelController _controller;
        public void SetController(MyModelController controller)
        {
            _controller = controller;
        }
        public void showDialog()
        {
             this.ShowDialog();
        }
        public Label getLabel1()
        {
            return this._label1;
        }
    }
