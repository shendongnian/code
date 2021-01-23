    var listcount = listView1.Items.Count;
    for (var x = 0; x < listcount; x++)
    {
       var x1 = x;
       listView1.BeginInvoke((MethodInvoker)delegate
       {
          listView1.Items[x1].SubItems[1].Text = "ok";
          listView1.Items[x1].SubItems[2].Text = "ok";
          listView1.Items[x1].SubItems[3].Text = "done";
       });
    }
