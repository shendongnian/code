    public class Form3 {
        Form1 form1;
        void SetForm1Instance(Form1 inst) { 
            form1 = inst;
        }
         private void Add_Function()
         {
              // code...
              string node = form1.TreeView1.SelectedNode.Text;
              // more code
         }  
        //remaining Form3 code
    }
