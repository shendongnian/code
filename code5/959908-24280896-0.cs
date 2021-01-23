     for (int i = 0; i < length; i++)
            {
                try
                {
                   string img = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(img, localFilename);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                } 
            }
