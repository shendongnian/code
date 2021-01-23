    public class Class1
    {
        public void AccessForm() 
        {
           var thatForm = (Form1)Form.ActiveForm;
            var progressBar = thatForm.Controls.Cast<Control>().Where(a => a.Name =="progressBar1").FirstOrDefault();
            MessageBox.Show(progressBar.Name);
        }
    }
