    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
         public Form1()
         {
             InitializeComponent();
         }
         private void dep_Click(object sender, EventArgs e)
         {
            try
            {
                decimal newBalance;
                BankAccount bankAccount = new BankAccount();  // Instantiate your class.
                bankAccount.DepositAmount = Convert.ToDecimal(depAmt.Text); 
                newBalance = (Convert.ToDecimal(currentBalance.Text)) + bankAccount.DepositAmount;
                currentBalance.Text = newBalance.ToString();
            }
            catch
            {
                MessageBox.Show("ERROR", "Oops, this isn't good!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class BankAccount
    {
        decimal depositAmount;
        public decimal DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = value; }
        }
      }
    }
