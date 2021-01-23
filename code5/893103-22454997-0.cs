            void myProcess_Exited(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (listBox1.SelectedItem != null)
                {
                    listBox1.Items.RemoveAt(0);
                }
                if (listBox1.Items.Count > 0)
                {
                    button1.PerformClick();
                }
                else
                {
                    MessageBox.Show("All Done!!");
                }
            });
        }
