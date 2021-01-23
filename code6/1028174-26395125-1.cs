    public partial class TypeWriter : Window
    {
        public TypeWriter()
        {
            InitializeComponent();
            TypeText();
        }
        public async void TypeText()
        {
            await Task.Delay(1000);
            var text = "Hello, World! I'm simulating typing into this TextBox.";
            foreach (var character in text)
            {
                this.TextBox.Text += character;
                await Task.Delay(100);
            }
        }
    }
