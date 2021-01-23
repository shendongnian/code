        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Tag == null)
            {
                button1.Tag = "toogled";
                // run event 1
            }
            else
            {
                button1.Tag = null;
                // run event 2
            }
        }
