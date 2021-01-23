    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
            //disable button on main thread
            button1.Enabled = false;
            Thread worker = new Thread(() =>
            {
               //do time consuming job
               System.Threading.Thread.Sleep(2000);
               //enable button (from the main thread)
               this.Invoke((MethodInvoker)delegate
               {
                  textBox1.AppendText("Click " + e.Clicks + "\n");
                  button1.Enabled = true;
               });
            });
            worker.Name = "Button 1 worker";
            worker.Start();
    }
