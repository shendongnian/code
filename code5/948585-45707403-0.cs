    public partial class LoginForm : MaterialForm
        {
            static NLog.Logger logger = LogManager.GetLogger("LoginForm");
            HttpClient client;
            HttpResponseMessage response;
    
            public LoginForm()
            {
                InitializeComponent();
    
                materialLabelErrMessage.Visible = false;
            }
    
            #region GUI events
            private void BntCancel_Click(object sender, EventArgs e)
            {
                CancelLogin();
                Close();
            }
    
            private void BtnOK_Click(object sender, EventArgs e)
            {
                Login();
            }
    
            private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
    
            }
    
            private void TextBoxUsername_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
    
            #endregion
    
            #region Keyboard Helpers
            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
                {
                    CancelLogin();
                    Close();
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
            #endregion
    
            async void Login()
            {
                try
                {
                    pbLogin.Visible = true;
                    btnOK.Enabled = false;
    
                    materialLabelErrMessage.Text = string.Empty;
                    materialLabelErrMessage.Visible = false;
    
                    client = new HttpClient();
    
                    var user = new User() { Username = textBoxUsername.Text.Trim(), Password = StringUtils.Crypt(textBoxPassword.Text.Trim()) };
    
                    var url = Properties.Settings.Default.ServerBaseUrl + @"/api/account/VerifyUserNamePassword";
                    response = await client.PostAsync(url, user.AsJson());
    
                    if (response.IsSuccessStatusCode)    // Check the response StatusCode
                    {
                        var serSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };   
                        string responseBody = await response.Content.ReadAsStringAsync();
    
                        var loggedUser = JsonConvert.DeserializeObject<User>(responseBody, serSettings);
    
                        if (loggedUser.IsLogged == false && loggedUser.UserId == Guid.Empty)
                        {
                            logger.Warn(Properties.Resources.LOGINUsernameOrPasswordWrong + " Username:" + user.Username);
    
                            BeginInvoke((Action)(() =>
                            {
                                materialLabelErrMessage.Text = Properties.Resources.LOGINUsernameOrPasswordWrong;
                                materialLabelErrMessage.Visible = true;
                                pbLogin.Visible = false;
                                btnOK.Enabled = true;
                            }));
                        }
                        else
                        {
                            logger.Info(Properties.Resources.LOGINPassed + " Username:" + user.Username);
    
                            BeginInvoke((Action)(() =>
                            {
                                materialLabelErrMessage.Text = string.Empty;
                                materialLabelErrMessage.Visible = false;
    
                                Program.UserInfo = loggedUser;
    
                                DialogResult = DialogResult.OK;
                                pbLogin.Visible = false;
    
                            }));
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        pbLogin.Visible = false;
                        btnOK.Enabled = true;
    
                        materialLabelErrMessage.Text = Properties.Resources.LOGINUsernameOrPasswordWrong;
                        materialLabelErrMessage.Visible = true;
                        logger.Warn(Properties.Resources.LOGINUsernameOrPasswordWrong + " Username:" + user.Username);
                    }
                    else
                    {
                        pbLogin.Visible = false;
                        btnOK.Enabled = true;
    
                        materialLabelErrMessage.Text = Properties.Resources.LOGINCannotConnectToServer;
                        materialLabelErrMessage.Visible = true;
    
                        logger.Error("Reason: " + response.ReasonPhrase + " Message: " + response.RequestMessage + " Username:" + user.Username);
                    }
                }
                catch (ObjectDisposedException ex)
                {
                    logger.Error("Login has been canceled. " + ex.Message);
                    pbLogin.Visible = false;
                    btnOK.Enabled = true;
                }
                catch (Exception ex)
                {
                    logger.Error(Properties.Resources.LOGINUsernameOrPasswordWrong + " " + ex.Message);
                    pbLogin.Visible = false;
                    btnOK.Enabled = true;
                }
            }
    
            void CancelLogin()
            {
                if (client != null)
                { 
                    client.CancelPendingRequests();
                    client = null;
                }
            }
        }
