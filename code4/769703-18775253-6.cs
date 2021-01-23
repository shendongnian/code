    public class Traverse{
        public delegate void TraverseDelegate();
        private TraverseDelegate dlg;
        public Traverse(TraverseDelegate dlg){
            this.dlg=dlg;
        }
        public void traversemethod(){
            Console.WriteLine("Traverse function");
            dlg();
        }
    }
