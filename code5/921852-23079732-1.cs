    public class MyTextBox:TextBox
    {
        List<int> numberstobeallowed = Enumerable.Range(20, 340 - 20).ToList();
        public MyTextBox()
        {
            this.Leave += new EventHandler(MyTextBox_Leave);
        }
        void MyTextBox_Leave(object sender, EventArgs e)
        {
            if (numberstobeallowed.Contains(Convert.ToInt32(this.Text)))
                this.Text = string.Empty;
        }
    }
