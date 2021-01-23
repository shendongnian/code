            private void ResizeParentAccordingToLabelSize(Label resizedLabel)
        {
            int necessaryWidth = resizedLabel.Location.X + resizedLabel.Width;
            int necessaryHeight = resizedLabel.Location.Y + resizedLabel.Height;
            if (necessaryWidth > this.Width)
            {
                this.Width = necessaryWidth;
            }
            if (necessaryHeight > this.Height)
            {
                this.Height = necessaryHeight;
            }
        }
