    public class Form3 {
        TreeView _Form1TreeViewControl;
    
         public Form3(TreeView form1TreeViewControl) {
            InitializeComponent();
            _Form1TreeViewControl = form1TreeViewControl
         }
    
         private void Add_Function()
         {
              // code...
              string node = _Form1TreeViewControl.SelectedNode.Text;
              // more code
         }  
    
        //remaining Form3 code
    }
