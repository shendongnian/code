    // If the calling thread is different from the thread that
    // created the pictureBox control, this method creates a
    // SetImageCallback and calls itself asynchronously using the
    // Invoke method.
     // This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void SetPictureBoxCallback(Image image);  
 
    // If the calling thread is the same as the thread that created
    // the PictureBox control, the Image property is set directly. 
    
    private void SetPictureBox(Image image)
    {
        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        if (this.picturebox1.InvokeRequired)
        {    
            SetPictureBoxCallback d = new SetPictureBoxCallback(SetPictureBox);
            this.Invoke(d, new object[] { image });
        }
        else
        {
            picturebox1.Image= image; 
        }
    }
