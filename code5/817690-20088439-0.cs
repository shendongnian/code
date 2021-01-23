       int k = 0;
       byte[] b = new byte[100];
       for (; ; )
       {
           for (int i = 0; i < 100000; i++)
           { }
           k = s.Receive(b);
           MessageBox.Show(k + "");
           textBox1.Text = "Recieved...";
           for (int i = 0; i < k; i++)
           {
               textBox2.Text = textBox2.Text + Convert.ToChar(b[i]);
           }
           MessageBox.Show(k + "");
           ASCIIEncoding asen = new ASCIIEncoding();
           s.Send(asen.GetBytes("Automatic message:" + "String received by server!"));
           textBox1.Text = "\n Automatic message sent!";
           MessageBox.Show(k + "");
         }
         s.Close();
