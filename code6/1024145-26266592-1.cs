    public class MyApplication
    {
        public void DoSomething()
        {
            var b = new Button();
            b.Click += b_Click;
        }
        public void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text) {
                case "Kittens":
                    return;
                default:
                    return;
            }
        }
    }
