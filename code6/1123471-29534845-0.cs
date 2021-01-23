    public interface IMethod
    {
    void aMethod();
    }
    public partial class Form1 : Form,IMethod
    public MyLibraryClass(IMethod form)
        {
            this._form = form;
            this._form.aMethod(); 
        }
