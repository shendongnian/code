    AxMsRdpClient7NotSafeForScripting newrdp = new AxMsRdpClient7NotSafeForScripting();
                    newrdp.Name = "RDPControl";
                    tab.Controls.Add(newrdp);
                    tab.Size = new System.Drawing.Size(814, 508);
    
                    tabControl.TabPages.Add(tab);
                    tabControl.SelectedTab = tab;
                    ConnectNewTab(newrdp, serverTextBox.Text, usernameTextBox.Text, passwordTextBox.Text);
