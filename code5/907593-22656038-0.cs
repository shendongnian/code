    private void OnConnect(IAsyncResult ar)
        {
            StateObject state = new StateObject();
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                // StateObject state = new StateObject();
                state.workSocket = client;
                //We are connected so we login into the server
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Login;
                msgToSend.strName = textBox2.Text;
                msgToSend.strMessage = null;
                byte[] b = msgToSend.ToByte();
                //Send the message to the server
                //HERE - Starts freezing the UI thread, continues to do background operations
                state.workSocket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(OnSend),
                    state.workSocket);
                state.workSocket.BeginReceive(state.buffer,
                    0,
                    state.buffer.Length,
                    SocketFlags.None,
                    new AsyncCallback(OnReceive),
                    state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //use this when you want to update the gui
            this.BeginInvoke(new MethodInvoker(() =>
            {
                //panel4.Visible = false;
                //panel1.Visible = true;
            }));
        }
        public void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));
                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        // All the data has been read from the 
                        // client. Display it on the console.
                        //do something with the data, if you update gui use BeginInvoke:
                        //all your bytes are in state.sb
                        Data msgReceived = new Data(state.buffer);
                        //Accordingly process the message received
                        switch (msgReceived.cmdCommand)
                        {
                            case Command.Login:
                                //lstChatters.Items.Add(msgReceived.strName);
                                break;
                            case Command.Logout:
                                //lstChatters.Items.Remove(msgReceived.strName);
                                break;
                            case Command.Message:
                                break;
                            case Command.List:
                                MessageBox.Show(msgReceived.strName);
                                //contacts.Add(msgReceived.strName);
                                needUpdate = true;
    //Here you can use BeginInvoke or invoke   
    //lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        //        //lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        //        //txtChatBox.Text += "<<<" + strName + " has joined the room>>>\r\n";
                        //        break;
                        //}
                    }
                } else {
                // Not all data received. Get more.
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(OnReceive), state);
            }
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SGSclientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
