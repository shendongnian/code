    public class Form1 : Form
    {
       Form1 instance = null;
    
       public Form1()
       {
           InitializeComponent();
           instance = this;
       }
    
       private static void MyMethod()
       {
          if (instance != null)
             instance.label1.Color = Color.White; //Or whatever
       }
    }
