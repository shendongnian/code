    public class ParentForm : Form
    {
        public void Foo()
        {
            ChildForm2 child = new ChildForm2();
            child.TextboxEdited += PropertyEditValue;
            child.Show();
        }
    }
