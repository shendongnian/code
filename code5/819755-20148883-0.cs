            private int emailLength;
            private ProgressBar ProgressBar1 = new ProgressBar();
    
             public void Main()
             {
                emailLength = 16;
                progressBar1.Maximum = emailLength;
                sendEmails();
             }
             public void sendEmails()
             {
                 for (int i = 0; i <= emailLength; i++)
                 {
                    //Send Emails Here
                    progressBar1.Increment();
                 }
             }
