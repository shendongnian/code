    private void button1_Click(object sender, EventArgs e)
    {
      // check to see if all the fields have been filled in properly
      if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.SelectedItem == null)
      {
          MessageBox.Show("Please fill in all fields");
      }
      else
      {
          DialogResult = DialogResult.OK;
          Close();
      }
    }
