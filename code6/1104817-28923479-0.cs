    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormInstances.frm = this;
            new Facade();
        }
        
        public OpenFileDialog ReturnOpenFileDialog()
        {
            return openFileDialog1;
        }
    }
    public static class FormInstances
    {
        public static Form1 frm { get; set; }
    }
    public class Facade
    {
        public Facade()
        {
           OpenFileDialog f= FormInstances.frm.ReturnOpenFileDialog();
            f.Filter="DLL|*.dll";
            f.ShowDialog();
            
        }
    }
