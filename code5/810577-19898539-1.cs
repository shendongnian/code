    if ((bool)this.Invoke((Func<bool>)delegate
      {
      return MessageBox.Show("Test Message", 
                             "Test Title", 
                             MessageBoxButtons.YesNo) == DialogResult.No;
      }))
    {
        Console.WriteLine("No was indeed selected.");
    }
