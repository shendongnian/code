        private void button1_Click(object sender, EventArgs e)
        {
            int CaptchaWidth = getXoffset(webBrowser1.Document.GetElementById("Captch-Element-Name"));
            int CaptchaHeight = getYoffset(webBrowser1.Document.GetElementById("Captch-Element-Name"));
            Bitmap bitmap = new Bitmap(CaptchaWidth, CaptchaHeight);
            webBrowser1.DrawToBitmap(bitmap, new Rectangle(0, 0, CaptchaWidth, CaptchaHeight));
            //now load the image into your pictureBox (you might need to convert the bitmap to a image)
        }
        //Methods to get Co-ordinates Of an Element in your webbrowser
        public int getXoffset(HtmlElement el)
        {
            int xPos = el.OffsetRectangle.Left;
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                xPos += tempEl.OffsetRectangle.Left;
                tempEl = tempEl.OffsetParent;
            }
            return xPos;
        }
        public int getYoffset(HtmlElement el)
        {
            int yPos = el.OffsetRectangle.Top;
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                yPos += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }
            return yPos;
        }
