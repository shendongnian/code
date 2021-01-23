    private void btn_Fetch_Click(object sender, RoutedEventArgs e)
    {
        if (buffer != null)
        {
            using (server)
            {
                server.Receive(buffer);
                txt_Log.AppendText(System.Text.Encoding.Default.GetString(buffer));
                buffer = null;
            }
        }
        else
        {
            txt_Log.AppendText("\nNo data to send.");
        }
    }
