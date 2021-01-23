    RichTextBox myRichTextBox = new RichTextBox();
    RichOLE mRichOle = new RichOLE(myRichTextBox);
    ...
    private void UglyChangeFontSize(RichTextBox rtb, float newSize = -1f, FontFamily fontFamily = null) {
        if (rtb.SelectionFont != null) {
            if (newSize < 0) newSize = rtb.SelectionFont.Size;
            if (fontFamily == null) fontFamily = rtb.SelectionFont.FontFamily;
            rtb.SelectionFont = new Font(fontFamily, newSize, rtb.SelectionFont.Style);
        }
        else {
            Cursor = Cursors.WaitCursor;
            // Hide the modifications from the user
            External.LockWindowAndKeepScrollPosition(rtb, () => 
            {
                // Backup Selection
                var sel = rtb.SelectionStart;
                var selLen = rtb.SelectionLength;
                // Disable UNDO for this "in pieces modifications" [START]
                rtb.SelectedRtf = rtb.SelectedRtf; // Required to allow Undo
                //mFontLockEvents = true; // RicherTextBox
                mRichOle.EnableUndo(false);
                // Disable UNDO for this "in pieces modifications" [END]
                // Change, char by char
                for (int k = 0; k < selLen; k++) {
                    rtb.Select(sel + k, 1);
                    // again, ugly... buuut we have Branch Prediction (google it)
                    if (newSize < 0) newSize = rtb.SelectionFont.Size;
                    var ff = fontFamily ?? rtb.SelectionFont.FontFamily;
                    rtb.SelectionFont = new Font(fontFamily, newSize, rtb.SelectionFont.Style);
                }
                // Disable UNDO for this "in pieces modifications" [START]
                //mFontLockEvents = false; // RicherTextBox
                mRichOle.EnableUndo(true);
                // Disable UNDO for this "in pieces modifications" [END]
                // Restore Selection
                rtb.SelectionStart = sel;
                rtb.SelectionLength = selLen;
            });
            Cursor = Cursors.Default;
        }
    }
