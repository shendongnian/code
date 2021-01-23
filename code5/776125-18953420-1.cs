        private void SendSettingsButtonClick(object sender, System.EventArgs e)
        {
            // check the _comPort instance first, if not assigned, leave a message..
            if(_comPort == null)
            {
                MessageBox.Show("The comport is not initialized");
                return;
            }
            var availablePorts = _systemPorts;
            if (availablePorts != null && availablePorts.Any())
            {
               SaveSettings();
               SendMessageTest();
            }
            else
            {
                _comPortComboBox.Text = "No Ports are available";
            }
        }
