    public partial class CommonForm : Form
    {
        public CommonForm(MyTopScreen parent)
        {
           // available
           parent._myVariable;
        }
    }
    CommonForm commonGridForm = new CommonForm(this);
