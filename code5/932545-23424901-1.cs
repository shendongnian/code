    public partial class Form2 : Form
        { 
            //here I  suppose that you have added another listbox on your form2 
            public Form2(ListBox.ObjectCollection items )
            {
                InitializeComponent();
                 
                listBox1.Items.AddRange(items)          ;}
          
        }
