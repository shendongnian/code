        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;
            var enc = new System.Text.UTF7Encoding();
            string buffer, rangeAddress;
            if (m.Msg == WM_PASTE)
            {
                if (Clipboard.ContainsText())
                {
                    string clip = Clipboard.GetText();
                    var dataObject = Clipboard.GetDataObject();
                    var mstream = (MemoryStream)dataObject.GetData("Link Source", true);
                    if(mstream == null) return;
                    var rdr = new System.IO.StreamReader(mstream, enc, true);
                    buffer = rdr.ReadToEnd();
                    buffer = StripWeirdChars(buffer);
                    int IndexExcl = buffer.IndexOf("!");
                    if (IndexExcl >= 0)
                    {
                        rangeAddress = buffer.Substring(IndexExcl + 1, buffer.Length - IndexExcl - 4);
                        // do whatever you want to do with it, e.g.:Globals.ThisAddIn.Application.ActiveCell.Value = rangeAddress;
                        return;
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
