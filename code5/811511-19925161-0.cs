    void Button_X_Click(object args, Events e) {
       Form f = Form1.ActiveForm;
       Form1.ActiveForm.WindowState = WindowState.Minimized;
       DialogResult dr = MessageBox.Show( this,  "Would you like to open Form?",
                                         "Title", MessageBoxButtons.YesNo );
       if (dr == System.Windows.Forms.DialogResult.Yes) {
         f.WindowState = FormWindowState.Maximized;
         MessageBox.Show("Done"); //For Testing
       }
    }
