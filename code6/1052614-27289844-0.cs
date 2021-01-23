     private void Form1_Load(object sender, EventArgs e)
        {
            m_dev = DASK.Register_Card(DASK.PCI_7250, 0);
            if (m_dev < 0)
            {
                MessageBox.Show("Register_Card error!");
             
            }
            FunctionToCall();
       }
    private void FunctionToCall()
         {
        
            short ret;
            uint int_value;
            var thread = new Thread(() =>
                {
                    while (true)
                    {
                        ret = DASK.DI_ReadPort((ushort)m_dev, 0, out int_value);
                        if (ret < 0)
                        {
                            MessageBox.Show("D2K_DI_ReadPort error!");
                            return;
                        }
                        if (int_value > 0)
                       {
                           textBox2.Invoke(new UpdateText(DisplayText), Convert.ToInt32(int_value));
            
                        }
                        
                        Thread.Sleep(500);
                    }
                });
            thread.Start();
            thread.IsBackground = true;
        }
        private void DisplayText(int i)
        {
         
            textBox2.Text = i.ToString();
        }
