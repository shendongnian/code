        using System.Threading;
        private string text = "this is my test string";
        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(loop).Start();
        }
        private void loop()
        {
            for (int i = 0; i < text.Length; i++)
            {
                AddChar(text[i]);
                Thread.Sleep(50);
            }
        }
        private void AddChar(char c)
        {
            if (label1.InvokeRequired)
                Invoke((MethodInvoker)delegate { AddChar(c); });
            else
                label1.Text += c;
        }
