        private Bitmap DisplayImage = null;
        public void SetImage(Bitmap Image)
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { SetImage(Image); });
            else
            {
                if (DisplayImage != null)
                    DisplayImage.Dispose();
                DisplayImage = (Bitmap)Image.Clone();
                picFrame.Image = DisplayImage;
            }
        }
