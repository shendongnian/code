        private bool shouldEvaluateReponse = false;
        
        private void btnReboot_Click(object sender, EventArgs e)
        {
                webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("username")[0].SetAttribute("value", usernameBox.Text);
                webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("password")[0].SetAttribute("value", passwordBox.Text);
                webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("submit")[0].InvokeMember("click");
                shouldEvaluateResponse = true;
                webBrowser1.Navigate("http://darkbox.nl/usercp.php?action=usergroups");
        }
        
        public void WebBrowser1_Navigated(object sender,  WebBrowserNavigatedEventArgs e)
        {
           //ignore this method if the flag isn't set.
           if (!shouldEvaluateResponse) return; 
           
           //reset the flag so this method doesn't keep executing
           shouldEvaluateResponse = false;
    
           if (webBrowser1.DocumentText.Contains("Registered Plus"))
           {
                    label3.Text = "You're plus";
           }
           else
           {
                    label3.Text = "You're not plus";
           }
        }
