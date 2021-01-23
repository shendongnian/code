    using System;
    using System.Windows.Forms;
    // Form1 code.
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
          Form2 frm2 = new Form2();  // Instantiate your form2 object.
          public Form1()
          {
             InitializeComponent();
             frm2.Show();  // Show the form.
          }
          private void button_save_Click(object sender, EventArgs e)
          {
             SaveFileDialog saveDlg = new SaveFileDialog();
             saveDlg.ShowDialog();  // This shows a 'Save' dialog.
             if (saveDlg.ShowDialog() == DialogResult.OK)  // Capture user input from the dialog.
             {
                // do some work here
             }
          }
          private void dontsave_Click(object sender, EventArgs e)
          {
            frm2.ClearTextBox(frm2); // Call the 'ClearTextBox' function from form2.
          }
          private void cancel_Click(object sender, EventArgs e)
          {
            this.Close(); // NOTE:  Probably better to use Application.Exit() here.
          }
       }
    }    
    //Form2 code.
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
       public partial class Form2 : Form
       {
          public Form2()
          {
             InitializeComponent();            
          }
          public void ClearTextBox(Form form) // Pass a form as an overload.
          {
             textBox1.Text = ""; // Clear the textbox.
          }
       }
    }
