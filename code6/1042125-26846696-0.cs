     var mutexId = "MyApplication";
     using (var mutex = new Mutex(false, mutexId))
     {
        if (!mutex.WaitOne(0, false))
        {
           MessageBox.Show("Only one instance of the application is allowed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
           return;
        }
        // Do scome work
     }
