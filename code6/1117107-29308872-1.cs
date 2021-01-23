    string currentHandle = driver.CurrentWindowHandle;
    PopupWindowFinder popUpWindow = new PopupWindowFinder(driver);
    string popupWindowHandle = popUpWindow.Click(EMailLink );
    driver.SwitchTo().Window(popupWindowHandle);
    
    //then do the email stuff
    
     var toEmailAddress  = driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtTo"));
                    toEmailAddress.Clear();
                    toEmailAddress.SendKeys("msbyuva@gmail.com");
    
    
                var chkEmailAttachment = driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$ChkAttachMent"));
                chkEmailAttachment.Click();
    
                var sendEmailButton = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_BtnSend"));
                sendEmailButton.Click();
            }
        }
    }
    
    //closing pop up window
    driver.Close();
    driver.SwitchToWindow(currentHandle);
