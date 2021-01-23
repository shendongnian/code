    public void getFrames(object sender, EventArgs e)
    {//Gets a frame from the IP cam
        //Replace "IPADDRESS", "USERNAME", "PASSWORD" 
        //with respective data for your camera
        string sourceURL = "http://IPADDRESS/snapshot.cgi?user=USERNAME&pwd=PASSWORD";
        //used to store the image retrieved in memory
        byte[] buffer = new byte[640 * 480];
        int read, total = 0;
        
        //Send a request to the peripheral via HTTP
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
        WebResponse resp = req.GetResponse();
        //Get the image capture after recieving a request
        //Note: just a screenshot not a steady stream
        Stream stream = resp.GetResponseStream();
        while ((read = stream.Read(buffer, total, 1000)) != 0)
        {
            total += read;
        }//While End
        //Convert memory (byte) to bitmap and store in a picturebox    
        pictureBox1.Image = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));
    }//getFrames End
    private void button1_Click(object sender, EventArgs e)
    {//Trigger an event to start running the function when possible
        Application.Idle += new EventHandler(getFrames2);
    }//Button1_Click End
