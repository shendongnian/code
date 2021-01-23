public partial class BankForm : Form
{
    private BankAccount _bankAccount { get; set; }
   
    private void setDepositButton_Click(object sender, EventArgs e) 
    {
        double deposit = double.Parse(setDepositTextBox.Text);
    
        if (_bankAccount = null)
        {
           _bankAccount = new BankAccount(deposit);
           listBox.Items.Add(string.Format("Initial Deposit: {0}", setDepositTextBox.Text);
        }
        else
        {
            _bankAccount.AddDeposit(deposit);
           listBox.Items.Add(string.Format("Deposit: {0}", setDepositTextBox.Text);
        }     
       
        listBox.Items.Add(string.Format("Balance: {0}", _bankAccount.Balance);
     }
          
     ...
}
good luck!!!
