    private delegate void UpdateMotionDisplayCallback(string text);
    private void UpdateMotionDisplay(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.motionDisplay.InvokeRequired) {
                UpdateMotionDisplayCallback d = new UpdateMotionDisplayCallback(UpdateMotionDisplay);
                this.Invoke(d, new object[] { text });
            } else {
                this.motionDisplay.Text = text;
            }
        }
