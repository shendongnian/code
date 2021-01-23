    public class ParentForm : Form
    {
        public void ClearTextBoxes(textboxes[] tb)
        {
            //Code for clearing text boxes
        }
    }
    public class MyForm : ParentForm
    {
        public void SomeMethod()
        {
            //More code
            clearTextBoxes(textboxes[] tb);
        }
    }
