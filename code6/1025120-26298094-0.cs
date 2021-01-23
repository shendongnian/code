    namespace Test{
        public partial class Form1 : Form 
        {
        MyClass MyClassObject;
            public Form1()
            {
                InitializeComponent();
                MyClassObject=new MyClass(this);
                MyClassObject.test("hello");
            }   
        }
        }
        
    namespace Test{
        class MyClass
        {
    
           Form1 parent;
    
           public MyClass(Form1 parentForm)
           {
                 parent=parentForm;
           }
           public void test (string text) 
           {
             parent.richtextbox1.clear();
           }
        }
   }
