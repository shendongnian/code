        delegate void UpdateWriteboxCallback(String str);
        public void wbWriteBox(string WriteString)
        {
            if (!String.IsNullOrEmpty(WriteString))
            {
                if (rtbWatchbox.InvokeRequired)
                {
                    UpdateWriteboxCallback at = new UpdateWriteboxCallback(wbWriteBox);
                    this.Invoke(at, new object[] { WriteString });
                }
                else
                {
                     // append richtextbox as required
                }
            }
         }
