    public Form2()
    {
        InitializeComponent();
        TextBox1.CharacterCasing = CharacterCasing.Lower;
    }
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsLetter(e.KeyChar);
    }
