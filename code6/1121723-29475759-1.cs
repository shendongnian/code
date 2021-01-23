    public class Form3 : Form
    {
         MyClass currentItemToEdit = null;
         public Form3(MyClass itemToEdit)
         {
             InitializeComponent();
             currentItemToEdit = itemToEdit;
             txtBoxTitle.Text = currentItemToEdit.Title;
             ......
         }
    }
