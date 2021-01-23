        public void SetImage(Bitmap Image)
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { SetImage(Image); });
            else
                picFrame.Image = (Bitmap)Image.Clone();
        }
