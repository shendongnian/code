    public class Example
    {
        public Button MyButton1 { get; set; }
        public Example(Button myButton1)
        {
            MyButton1 = myButton1;
        }
        public void CloseAllConnections()
        {
            MyButton1.Text = "Disconnecting all";
        }
    }
