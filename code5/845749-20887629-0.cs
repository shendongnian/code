    public void MyProg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        if (e.Error != null) {
            // You have an exception, which you can examine through the e.Error property.
            //display your exception details here
        } else {
            // No exception in DoWork.
           //happy ending
            }
        }
    }
