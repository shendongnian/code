    private void pos_test_button_Click(object sender, EventArgs e)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect("127.0.0.1", 7777);
            string get_menu_request = "{\"request\": \"get_menu\"}";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(get_menu_request);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string _returndata = System.Text.Encoding.ASCII.GetString(inStream);
            test_log_box.AppendText("\r\n\r\nPOS Connection Test: " + "\r\n" + _returndata);
        } 
