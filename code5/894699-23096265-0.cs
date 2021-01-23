        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                #region Display all available COM Ports
                string[] ports = SerialPort.GetPortNames();
                // Add all port names to the combo box:
                foreach (string port in ports)
                {
                    this.comboBox1.Items.Add(port);
                }
                #endregion
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
