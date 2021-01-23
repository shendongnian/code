    public class MyButton : Button
    {
        public int ButtonID { get; set; }
    }
    public class MyApplication
    {
        public void DoSomething()
        {
            int i; // todo: loop stuff
            var button = new MyButton
            {
                Text = getFlavor(path) + "\t(" + path + ")",
                Width = Width,
                Height = 35,
                Top = y,
                ButtonID = i
            };
        }
    }
