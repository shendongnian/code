    public Form1() {
      InitializeComponent();
      textBox1.MinimumSize = new Size(32, 0);
      textBox2.MinimumSize = new Size(32, 0);
      textBox3.MinimumSize = new Size(32, 0);
      textBox1.TextChanged += textBox_TextChanged;
      textBox2.TextChanged += textBox_TextChanged;
      textBox3.TextChanged += textBox_TextChanged;
    }
    void textBox_TextChanged(object sender, EventArgs e) {
      TextBox tb = sender as TextBox;
      if (tb != null) {
        tb.Width = TextRenderer.MeasureText(tb.Text, tb.Font, Size.Empty, 
                                TextFormatFlags.TextBoxControl).Width + 8;
      }
    }
