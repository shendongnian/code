    void checkBox1_CheckedChanged(object sender, EventArgs e) {
      Binding b = checkBox1.DataBindings["Checked"];
      if (b != null) {
        b.WriteValue();
      }
      Debug.WriteLine(TestBool.ToString());
    }
