    public delegate void GetBitMapDelegate(Bitmap bit);
    public event GetBitMapDelegate GetBitMap;
    //Your method
    try
    {
        Bitmap bit;
        var t = new Thread((ThreadStart)(() =>
        {
            string picUri = "";
            if (ONLINE_MODE_CHKBOX.Checked)
            {
                picUri = "http://minecraft.aggenkeech.com/body.php?u=" + GetSessionId(true) + "&s=128&r=255&g=250&b=238";
            }
            else
                picUri = "http://minecraft.aggenkeech.com/body.php?u=%USERNAME%&s=128&r=255&g=250&b=238";
            picUri = picUri.Replace("%USERNAME%", USERNAME_TXT.Text);
            // Create the requests.
            WebRequest requestPic = WebRequest.Create(picUri);
            WebResponse responsePic = requestPic.GetResponse();
            Image webImage = Image.FromStream(responsePic.GetResponseStream());
            Color red = Color.FromArgb(255, 255, 250, 238);
            bit = new Bitmap(webImage);
            bit.MakeTransparent(red);
            GetBitMap(bit);
        }));
        t.Start();
        SKIN_PICTURE_BOX.Image = bit; //<<<< Here it returns an error : Error, Use of unasigned local variable 'bit'
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
