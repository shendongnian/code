    private void button1_Click(object sender, EventArgs e)
    {   
        if (panel3.Visible)
        { 
            // make invisible
            panel3.Visible = false;
            // storedHeight is a private member of the Form
            storedHeight = Form1.ActiveForm.Height;
            Form1.ActiveForm.Height = minimumHeight;  // Set to predetermined minimum height 
         }
         else
         {
             // make visible
             panel3.Visible = true;
             Form1.ActiveForm.Height = storedHeight;
         }
    }
