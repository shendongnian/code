    private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        int loopValX = 0;
        int loopValY = -150;
        for (int serial = 0; serial < SaveBeforePrint.Count; serial++)
        {
            String intercharacterGap = "0";
            String str = '*' + SaveBeforePrint[serial].ToUpper() + '*';
            int strLength = str.Length;
            for (int i = 0; i < SaveBeforePrint[serial].Length; i++)
            {
                string barcodestring = SaveBeforePrint[serial].ToUpper();
                if (alphabet39.IndexOf(barcodestring[i]) == -1 || barcodestring[i] == '*')
                {
                    e.Graphics.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10);
                    return;
                }
            }
            String encodedString = "";
            for (int i = 0; i < strLength; i++)
            {
                if (i > 0)
                    encodedString += intercharacterGap;
                encodedString += coded39Char[alphabet39.IndexOf(str[i])];
            }
            int encodedStringLength = encodedString.Length;
            int widthOfBarCodeString = 0;
            double wideToNarrowRatio = 3;
            if (align != AlignType.Left)
            {
                for (int i = 0; i < encodedStringLength; i++)
                {
                    if (encodedString[i] == '1')
                        widthOfBarCodeString += (int)(wideToNarrowRatio * (int)weight);
                    else
                        widthOfBarCodeString += (int)weight;
                }
            }
            
            SizeF hSize = e.Graphics.MeasureString(headerText, headerFont);
            SizeF fSize = e.Graphics.MeasureString(SaveBeforePrint[serial], footerFont);
            int headerX = 0;
            int footerX = 0;
            if (align == AlignType.Left)
            {
                x = leftMargin;
                headerX = leftMargin;
                footerX = leftMargin;
            }
            
            else if (align == AlignType.Center)
            {
                    x = (Width - widthOfBarCodeString) / 2;
                    headerX = (Width - (int)hSize.Width) / 2;
                    footerX = (Width - (int)fSize.Width) / 2;
            }
            else
            {
                x = Width - widthOfBarCodeString - leftMargin;
                headerX = Width - (int)hSize.Width - leftMargin;
                footerX = Width - (int)fSize.Width - leftMargin;
            }
            if (showHeader)
            {
                y = (int)hSize.Height + topMargin;
                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, headerX, topMargin);
            }
            else
            {
                y = topMargin;
            }
            //start changes by Deepak
            if (serial % 4 == 0)
            {
                loopValX = 0;
                loopValY += 150;
            }
            else
            {
                loopValX += 150;
            }
            x += loopValX;
            y += loopValY;
            footerX += loopValX;
            //end changes by Deepak
            for (int i = 0; i < encodedStringLength; i++)
            {
                    if (encodedString[i] == '1')
                        wid = (int)(wideToNarrowRatio * (int)weight);
                    else
                        wid = (int)weight;
                    e.Graphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, x, y, wid, height);
                    x += wid;
              
            }
            y += height;
            
            if (showFooter)
                e.Graphics.DrawString(SaveBeforePrint[serial], footerFont, Brushes.Black, footerX, y);
        }
    }
