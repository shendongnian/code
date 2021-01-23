       private void Accept()
        {
            try {
                n = server_socket.Accept();
                richTextBox_server_activity_log.AppendText("Connection Established...");
            } catch (Exception ex) {
                richTextBox_server_activity_log.AppendText("Failed to Connect...");
            }
        }
