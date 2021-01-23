        private void MakeAsynchronousCall(int NumberOfStudents)
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            StudentService.StudentServiceClient c =
                new WFCCallExample.StudentService.StudentServiceClient();
            EndpointAddress endpointAddress = c.Endpoint.Address;
 
            StudentService.IStudentService iStudentService =
                new ChannelFactory<StudentService.IStudentService>
                (basicHttpBinding, endpointAddress).CreateChannel();
 
            AsyncCallback aSyncCallBack =
                delegate(IAsyncResult result)
            {
                try
                {
                    List<StudentService.Student> Students =
                        iStudentService.EndGetStudents(result);
 
                    this.Dispatcher.BeginInvoke((Action)delegate
                    { DGStudent.ItemsSource = Students; });
                }
                catch (Exception ex)
                {
                    this.Dispatcher.BeginInvoke((Action)delegate
                    { MessageBox.Show(ex.Message); });
                }
            };
 
            try
            {
                iStudentService.BeginGetStudents(NumberOfStudents,
                    aSyncCallBack, iStudentService);
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
