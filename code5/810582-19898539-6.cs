        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread T = new System.Threading.Thread(Foo);
            T.Start();
        }
        private void Foo()
        {
            if (Response("test") == System.Windows.Forms.DialogResult.No)
            {
                Console.WriteLine("No was indeed selected.");
            }
        }
        delegate DialogResult ResponseDelegate(string text);
        private DialogResult Response(string text)
        {
            if (this.InvokeRequired)
            {
                return (DialogResult)this.Invoke(new ResponseDelegate(Response), new object[] { "test" });
            }
            else
            {
                return MessageBox.Show(text, "", MessageBoxButtons.YesNo);
            }
        }
