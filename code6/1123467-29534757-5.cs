	public class MyLibraryClass
    {
        private IMyInterface _form;
        public MyLibraryClass(IMyInterface form)
        {
            this._form = form;
            this._form.aMethod(); // now is work :)
        }
    }
