    public class Resources : IDisposable
    {
        public MyForm MyForm {get;set;}
        public MyControl MyControl {get;set;}
        //etc...
        public void Dispose()
        {
             if(MyForm != null)
                  MyForm.Dispose()
             if(MyControl != null)
                  MyControl.Dispose()
             //etc..
        }
    }
