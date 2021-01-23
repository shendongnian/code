    void CheckQuantity()
            {
                string msg = "";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string productCode = row.Cells[0].Value.ToString();
                    decimal quantity = Convert.ToDecimal(row.Cells[1].Value);
                    if (quantity < 5)
                    {
                        msg += "- Product Code: " + productCode + " - Quantity: " + quantity + "\n";
                    }
                }
                if (msg != "")
                {
                    SystemManager.SoundEffect("C:/Windows/Media/Speech Off.wav");
                    customToolTip1.Show(msg, this, _screen.Right, _screen.Bottom, 5000);
                }
            }
    
    void Timer_Tick(object sender, EventArgs e)
            {
                _timer.Stop();
                CheckQuantity();
            }
    
    void Database_Load(object sender, EventArgs e)
            {
                _timer.Interval = 15 * 1000;
                _timer.Start();
            }
    
    void Database_FormClosed(object sender, FormClosedEventArgs e)
           {
                _timer.Stop();
           }
