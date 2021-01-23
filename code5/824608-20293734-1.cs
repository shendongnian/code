    public Form1()
    {
      InitializeComponent();
      TypeText("this is a text");
    }
    private void TypeText(string text)
    {
      textBox1.Clear(); // Make sure the textbox is empty
      Thread thread = new Thread(delegate() // Create a new thread which fills the textbox periodically
        {
          button1.BeginInvoke((MethodInvoker)delegate { button1.Enabled = false; }); // Disables the button
          for (int i = 0; i < text.Length; i++)
          {
            int temp = i; // Cache variable because without this, an 'ArgumentOutOfRange' Exception will be thrown
            textBox1.BeginInvoke((MethodInvoker)delegate // Invoke to main thread
            {
              textBox1.Text += text[temp]; // Fill with next char
            });
            if (text[temp] != ' ') // This makes sure the user doesn't have to wait the double of the time when there is an empty space for the new character
              Thread.Sleep(500); // This will stop the seperate thread for 500ms. Won't block the main thread
          }
          button1.BeginInvoke((MethodInvoker)delegate { button1.Enabled = true; }); // Reenables the button    
        });
      thread.Start(); // Start the new thread and continue the main thread
    }
