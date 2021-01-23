                    Form loginDisplay = null; 
                    this.Invoke(new Action(() =>
                        {
                            loginDisplay = LoginInfoForm(user, pass);
                            loginDisplay.Show(this);
                        }));
                    if (loginDisplay2 != null)
                    {
                        loginDisplay2.Enabled = false;
                    }
                    string input = "";
                    InputBox.Show("Input info", false, out input, parent: this, enable: loginDisplay);
