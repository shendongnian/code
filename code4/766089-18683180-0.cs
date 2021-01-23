      private void PopulateListView()
      {
         foreach (string curr in listBox1.Items)
         {
            string changed = "\\Images\\" + curr.Replace(".zip", ".jpg");
            if (File.Exists(changed))
            {
               imageList1.Images.Add(Image.FromFile(changed));
               listView1.Items.Add("", 1);
            }
         }
      }
