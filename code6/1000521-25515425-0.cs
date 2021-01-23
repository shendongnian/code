      private void TestForm_Load(object sender, EventArgs e)
      {
         for (int i = 0; i < 10; i++)
         {
            // add items to the combobox
            // you can use any object. The .ToString() method will be used for displaying it
            cbxTest.Items.Add("This is test string " + i);
         }
      }
