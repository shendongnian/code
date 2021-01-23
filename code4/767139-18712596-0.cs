      public UserControl1()
      {
         InitializeComponent();
         this.MouseDown += new MouseEventHandler(this.UserControl1_MouseDown);
         this.comboBox1.MouseDown += new MouseEventHandler(this.comboBox1_MouseDown);
      }
      private void UserControl1_MouseClick(object sender, MouseEventArgs e)
      {
          UCMouseDown();
      }
      private void UserControl1_MouseDown(object sender, MouseEventArgs e)
      {
          UCMouseDown();
      }
      private void comboBox1_MouseDown(object sender, MouseEventArgs e)
      {
          UCMouseDown();
      }
      private void UCMouseDown()
      {
          // Your code
      }
