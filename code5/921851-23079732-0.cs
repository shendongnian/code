    public class MyTextBox:TextBox
    {
        public MyTextBox()
        {
            this.KeyPress += new KeyPressEventHandler(MyTextBox_KeyPress);
        }
        void MyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<int> numberstobeallowed = new List<int> { 0, 1, 2, 3 };
            if(numberstobeallowed.Contains(Convert.ToInt32(e.KeyChar.ToString())))
                e.Handled =true;
            else 
                e.Handled = false;
        }
    }
