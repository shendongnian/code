		protected override void OnHandleCreated(EventArgs e) {
		    base.OnHandleCreated(e);
		    this.AutoSize = false;
		}
		
		protected override void OnFontChanged(EventArgs e) {
		    base.OnFontChanged(e);
		    this.Size = GetTextSize();
		}
		
		protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
		    this.Size = GetTextSize();
		}
		
		protected override void OnTextChanged(EventArgs e) {
		    base.OnTextChanged(e);
		    this.Size = GetTextSize();
		}
		
		private Size GetTextSize() {
		    Size padSize = TextRenderer.MeasureText(".", this.Font);
		    Size textSize = TextRenderer.MeasureText(this.Text + ".", this.Font);
		    return new Size(textSize.Width - padSize.Width, textSize.Height);
		}
