            this.timer.Stop();
            SendMessage(m_CapHwnd, WM_CAP_GT_FRAME, 0, 0);
            SendMessage(m_CapHwnd, WM_CAP_COPY, 0, 0);
            OpenClipboard(m_CapHwnd);
            CloseClipboard();
            IDataObject dataObj = Clipboard.GetDataObject();
            Image img = (System.Drawing.Bitmap)dataObj.GetData(DataFormats.Bitmap);
            //img.Save("e:\\test_" + DateTime.UtcNow.Ticks + ".jpg");
            pictureBox.Image = img;
            pictureBox.Refresh();
            Application.DoEvents();
            if (!bStopped)
            {
                this.timer.Start();
            }
