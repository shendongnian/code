    private static void UploadBtn_click(Object sender, EventArgs e)
    {
      using (SPSite osite = new SPSite("URL"))
      {
        using (SPWeb oWeb = osite.OpenWeb())
        {
          oWeb.AllowUnsafeUpdates = true;
          SPList list = oWeb.TryGetList("ListName");
          SPListItem item = list.AddItem();
          FileStream stream = new FileStream(UploadBtn.FileName, FileMode.Open) ;
          byte[] byteArray = new byte[stream.Length];
          stream.Read(byteArray, 0, Convert.ToInt32(stream.Length));
          stream.Close();
          item.Attachments.Add("myDoc.doc", byteArray);
          item["Title"] = TextBox1.Text;
          item.Update();
          oWeb.AllowUnsafeUpdates = false;
        }
      }
    }
