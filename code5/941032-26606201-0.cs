        private void adcnts_Click(object sender, RoutedEventArgs e)
        {
            aaaaaa();
            using (IsolatedStorageFile istf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream istfs = istf.OpenFile("MyContacts.xml", FileMode.Open))
                {
                    XDocument doc = XDocument.Load(istfs);
                    var query = from d in doc.Root.Descendants("Contacts")
                                select new
                                {
                                    firtName = d.Element("name").Value,
                                    mobilePhone = d.Element("phone").Value
                                };
                    //Global qq = new Global();
                    foreach (var po in query)
                    {
                        //qq.cnts.Add(new Contactss()
                        //{
                        //    name = po.firtName,
                        //    number = po.mobilePhone
                        //});
                        saveContactTask.FirstName = po.firtName;
                        saveContactTask.MobilePhone = po.mobilePhone;
                        saveContactTask.Show();
                    }
                }
            }
           // saveContactTask.Show();
           
        }
        public void aaaaaa()
        {
            saveContactTask = new SaveContactTask();
            saveContactTask.Completed += new EventHandler<SaveContactResult>(saveContactTask_Completed);
        }
        private void saveContactTask_Completed(object sender, SaveContactResult e)
        {
            switch (e.TaskResult)
            {
              // Logic for when the contact was saved successfully
                case TaskResult.OK:
                   MessageBox.Show("Contact saved.");
                    break;
             //Logic for when the task was cancelled by the user
                case TaskResult.Cancel:
                    MessageBox.Show("Save cancelled.");
                    break;
                //Logic for when the contact could not be saved
                case TaskResult.None:
                    MessageBox.Show("Contact could not be saved.");
                    break;
            }
        }
 
    }
