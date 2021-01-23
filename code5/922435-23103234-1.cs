        set {
            mImage = value;
            if (value == null) this.AutoScrollMinSize = new Size(0, 0);
            else {
                var size = value.Size;
                using (var gr = this.CreateGraphics()) {
                    size.Width = (int)(size.Width * gr.DpiX / value.HorizontalResolution);
                    size.Height = (int)(size.Height * gr.DpiY / value.VerticalResolution);
                }
                this.AutoScrollMinSize = size;
            }
            this.Invalidate();
        }
