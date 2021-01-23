    public class OtherForm : Form
    {
        Main_Form _mainForm;
        // Constructor
        public OtherForm(Main_Form theMainForm)
        {
            _mainForm = theMainForm;
        }
        public static void changeGridSize(int newSize)
        {
            _mainForm.changeGridSize(newSize);
        }
    }
