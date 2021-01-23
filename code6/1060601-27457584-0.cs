        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.ClientSize = new Size(
                this.ClientSize.Width,
                OKButton.Bottom + OKButton.Margin.Bottom
            );
        }
