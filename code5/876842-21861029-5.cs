    using System.Net;
    using System.IO;
    string url;
     
        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
            if (RetrieveBgrFrame.Checked)
            {
                Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
                //because we are using an autosize picturebox we need to do a thread safe update
                if (frame != null)
                {
                    DisplayImage(frame.ToBitmap());
                }
                else
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    // get response
                    WebResponse resp = req.GetResponse();
                    //get stream
                    Stream stream = resp.GetResponseStream();
                    if (!stream.CanRead)
                    {
                        //try reconnecting the camera
                        captureButtonClick(null, null); //pause
                        _capture.Dispose();//get rid
                        captureButtonClick(null, null); //reconnect
                    }
                }
            }
            else if (RetrieveGrayFrame.Checked)
            {
                Image<Gray, Byte> frame = _capture.RetrieveGrayFrame();
                //because we are using an autosize picturebox we need to do a thread safe update
                if (frame != null) DisplayImage(frame.ToBitmap());
            }
        }
      
        private void captureButtonClick(object sender, EventArgs e)
        {
            url = Camera_Selection.SelectedItem.ToString(); //add this
            ... the rest of the code
        }
    
