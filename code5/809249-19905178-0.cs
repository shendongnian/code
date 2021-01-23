        private void WebBrowser_DragOver(object sender, HtmlElementEventArgs e)
        {
            panel.BringToFront();
        }
        private void Panel_DragLeave(object sender, EventArgs e)
        {
            panel.SendToBack();
        }
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            panel.SendToBack();
        }
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            //Make dragdrop data processing
        }
