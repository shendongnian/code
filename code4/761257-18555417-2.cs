    public event EventHandler<Form2EventArgs> Form2Event;
    public class Form2EventArgs : EventArgs
    {
        // for illustration only:
        // do NOT use `object` and to NOT call it `Data`
        public object Data {get;set;}
    }
