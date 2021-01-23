    Stream myStream = openFileDialog1.OpenFile();
    if (myStream != null)
    {
        using (myStream)
        {
            Workflows w = new Workflows();
            byte[] bytes = new byte[s.Length];
            s.Read(bytes, 0, (int)s.Length);
            // change here to your actual field name
            w.FileData = bytes;
            // change here according to your context
            context.Workflows.Add(w);
            context.SubmitChanges();
        }
    }
