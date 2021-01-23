    public class AnotherForm
    {
        public InputValue { get; private set; }
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ...
            InputValue = input;
            ...
        }
    }
