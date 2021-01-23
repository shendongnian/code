        int count = 0;
        static string path = @"C:\\Users\\Jake_PC\\Desktop\\fitting\\";
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
            
            
            string ctr = dir.GetFiles().Length.ToString();
            if (RetrieveBgrFrame.Checked)
            {
                Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
                //because we are using an autosize picturebox we need to do a thread safe update
                DisplayImage(frame.ToBitmap());
                frame.ToBitmap().Save(@"C:\\Users\\Jake_PC\\Desktop\\fitting\\" + ctr + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                count++;
                if(count < 4)
                {
                    //this should really be reset in captureButtonClick() method 
                    //to prevent a frameready event fireing before disposeing is finsihed
                    count = 0; 
                    //Stop aquiring by simulating a form button press
                    captureButtonClick(null, null); 
                }
            }
            else if (RetrieveGrayFrame.Checked)
            {
                Image<Gray, Byte> frame = _capture.RetrieveGrayFrame();
                //because we are using an autosize picturebox we need to do a thread safe update
                DisplayImage(frame.ToBitmap());
                frame.ToBitmap().Save(@"C:\\Users\\Jake_PC\\Desktop\\fitting\\" + ctr + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                count++;
                if (count < 4)
                {
                    //this should really be reset in captureButtonClick() method 
                    //to prevent a frameready event fireing before disposeing is finsihed
                    count = 0;
                    //Stop aquiring by simulating a form button press
                    captureButtonClick(null, null);
                }
            }
        }
