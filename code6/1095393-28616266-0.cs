    ...
        if (sfd.ShowDialog() != true)
            return;
        try
        {
            using (var stream = sfd.OpenFile())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(TxtBox.Text);
            }
        }
    ...
