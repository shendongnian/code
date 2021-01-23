    public class AfyTransparentTextBox : TextBox
    {
        protected override void OnClick(EventArgs e)
        {
            System.Windows.MessageBox.Show("KY-KY");
 	        base.OnClick(e);
        }
    }
