    public partial class CharStats : Form
        {
    .....
     public void StatTransfer()
            {
                MainForm parentForm = this.parentForm;
                parentForm.formInit = 1;
                parentForm.SetInfo();
            }
    ......
    }
