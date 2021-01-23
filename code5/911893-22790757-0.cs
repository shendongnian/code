    private async void Start_Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            LoopCheck = true;
            try
            {
                while (LoopCheck)
                {
                    foreach (string word in WordsOfFile)
                    {
                        WordToShow = word;
                        await Task.Delay(1000);
                    }
                }
            }
            catch
            {
                Form2 ErrorPopup = new Form2();
                if (ErrorPopup.ShowDialog() == DialogResult.OK)
                {
                    ErrorPopup.Dispose();
                }
            }
        }
