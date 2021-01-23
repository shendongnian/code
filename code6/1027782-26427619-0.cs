    void checkBox1_CheckedChanged(object sender, EventArgs e) {
      //checkBox1.BindingContext[this].EndCurrentEdit();
      checkBox1.DataBindings[0].WriteValue();
      Debug.WriteLine(TestBool.ToString());
    }
