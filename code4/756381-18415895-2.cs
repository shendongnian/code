    //Check the connection
        void BeginCheck()
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create("http://google.co.uk");
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Internet connection available, server online
                    rspFP.Close();
                    ConnectionResultEvent(this, new ConnectionResultEventArgs {Available = true});
                }
                else
                {
                    // Other status - Server or connection not available
                    rspFP.Close();
                    ConnectionResultEvent(this, new ConnectionResultEventArgs { Available = false });
                }
            }
            catch (WebException)
            {
                // Exception - connection not available
                //Raise the Event - Connection False
                ConnectionResultEvent(this, new ConnectionResultEventArgs { Available = false });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //loading graphic, screen or whatever
            label1.Text = "Checking Connection...";
            //Begin the checks - Start this in a new thread
            Thread t = new Thread(BeginCheck);
            t.Start();
        }
