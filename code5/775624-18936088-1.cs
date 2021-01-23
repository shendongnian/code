    using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = storage.OpenFile("TestFile.txt", System.IO.FileMode.OpenOrCreate))
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter())
                    {
                        writer.WriteLine(email1.Text + "," + email2.Text + "," + email3.Text + "," + email4.Text);
                    }
                }
            }
