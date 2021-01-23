    public delegate void TraverseDelegate();
    public void traversemethod(TraverseDelegate dlg){
	Console.WriteLine("Traverse function");
	dlg();
    }
