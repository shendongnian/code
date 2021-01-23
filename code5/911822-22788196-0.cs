    public class Form2
    {
        public string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
    }
    
    public class MainForm
    {
        public void Foo()
        {
            Form2 child = new Form2();
            child.Name = mainForm.gvRow.Cells[2].Value.ToString();
            child.Show();
        }
    }
