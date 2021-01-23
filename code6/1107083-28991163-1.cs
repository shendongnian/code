    bool ret = (bool)myFormInstance.Invoke(
        new Func<DataClass, bool>(myFormInstance.DoStuff), 
        myData);
    public class MyForm : Form
    {
        public bool DoStuff(DataClass data)
        {
            ....
        }
    }
