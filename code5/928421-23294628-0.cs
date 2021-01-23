      private void interface_mouseDown(object sender, MouseButtonEventArgs e)
      {
        if (MyTextBlock.ClickCount == 2)
            MessageBox.Show("Yeah interfac " + MyTextBlock.Text);
      }
