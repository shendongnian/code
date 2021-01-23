    public class Form3 : Form
    {
         public MyClass ItemToEdit {get; set;}
         public Form3()
         {
             InitializeComponent();
         }
         protected void Form_Load(object sender, EventArgs e)
         {
             if(this.ItemToEdit != null)
             {
                 txtBoxTitle.Text = ItemToEdit.Title;
                  ......
             }
         }
    }
