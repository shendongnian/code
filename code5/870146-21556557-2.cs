    public class Form1 : Form
    {
        if (somethingHappened)
        {
            var formMessageBox = new FormMessageBox();
            
            //ShowDialog() sets the formMessageBox object as a modal dialog owned by Form1 
            DialogResult result = formMessageBox.ShowDialog();
            
            //Assuming you have OK buttons or something like that in formMessageBox
            if (result == DialogResult.OK)
            {
                var form3 = new Form3();
                /*Can't use this.Close() here as it would close the entire application
                Just hide it and don't forget to dispose of it later when you actually
                want the application to close*/
                this.Hide();
                
                form3.Show();
                
                
            }
        }
    }
