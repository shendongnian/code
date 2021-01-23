    public partial class FormB : Form
    {
       public string PhoneNumber { get; private set; }
       private void buttonClose_Click(object sender, EventArgs e)
       {
           this.PhoneNumber = textBoxPhone.Text;
           this.DialogResult = DialogResult.OK;
           this.Close();
       }
    }
