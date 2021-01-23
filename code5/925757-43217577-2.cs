    public class ParentClass
    {
        public void Execute()
        {
            UserControl oUserControl = new UserControl();
            oUserControl.oDel = Form1Action;
            oUserControl.Execute();
        }
        public object Form1Action(object obj)
        {
            string sObj = Convert.ToString(obj);
            Form1 oForm = new Form1();
            oForm.Execute(sObj);
            return null;
        }
    }
