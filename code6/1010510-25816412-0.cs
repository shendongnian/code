        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            _NextClipboardViewer = SetClipboardViewer(this.Handle);
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            ChangeClipboardChain(this.Handle, _NextClipboardViewer);
            base.OnHandleDestroyed(e);
        }
