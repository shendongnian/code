    private void getPrinters(string domain, string username, string password, string server, ComboBox cmbBox)
        {
            progressBar.Maximum = 3;
            progressBar.Step = 1;
            ConnectionOptions objConnection = new ConnectionOptions();
            objConnection.Username = username;
            objConnection.Authority = "ntlmdomain:" + domain;
            objConnection.Password = password;
            ManagementScope scope = new ManagementScope(@"\\" + server + @"\root\cimv2", objConnection);
            try
            {
                scope.Connect();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBoxButtons msgButton = MessageBoxButtons.OK;
                MessageBoxIcon msgIcon = MessageBoxIcon.Error;
                string msgText = "Cannot connect to " + serverPrint + ".";
                string msgTitle = "Connection Error";
                DialogResult result = MessageBox.Show(msgText, msgTitle, msgButton, msgIcon);
                return;
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBoxButtons msgButton = MessageBoxButtons.OK;
                MessageBoxIcon msgIcon = MessageBoxIcon.Error;
                string msgText = "Bad Username or Password.";
                string msgTitle = "Authentication Error";
                DialogResult result = MessageBox.Show(msgText, msgTitle, msgButton, msgIcon);
                return;
            }
            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(scope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            cmbBox.Items.Clear();
            foreach (ManagementObject mo in MOC)
            {
                string itemName = @"\\" + serverPrint + @"\" + mo["Name"].ToString();
                cmbBox.Items.Add(itemName);
            }
        }
