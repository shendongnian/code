    public Form1() {
      InitializeComponent();
      textBox1.Enter += LabelFocus;
      textBox2.Enter += LabelFocus;
      textBox3.Enter += LabelFocus;
    }
    void LabelFocus(object sender, EventArgs e) {
      TextBox tb = sender as TextBox;
      if (tb != null) {
        foreach (Label lbl in panel1.Controls.OfType<Label>()) {
          if (lbl.TabIndex == (tb.TabIndex - 1)) {
            lbl.ForeColor = Color.White;
          } else {
            lbl.ForeColor = Color.IndianRed;
          }
        }
      }
    }
