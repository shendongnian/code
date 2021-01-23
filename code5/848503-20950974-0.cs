    private void button2_Click(object sender, EventArgs e)
    {
        // You need to make sure that obj is not null when this button is clicked.
        // One way is to disable this button until button1 is pressed. 
        // Or you can add this if statement.
        if(obj != null)
        {
            obj.StopWork();
        }
    }
