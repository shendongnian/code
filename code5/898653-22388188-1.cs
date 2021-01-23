    using SKYPE4COMLib;
    
    Skype skype;
                try
                {
                    skype = new SKYPE4COMLib.Skype();
                    if (!skype.Client.IsRunning)
                    {
                        skype.Client.Start(true, true);
                    }
                    //skype.Attach(8, true);
                    Call call = skype.PlaceCall(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
