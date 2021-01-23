    public void ReadCallback(IAsyncResult ar)
    {
        String content = String.Empty;
        // Retrieve the state object and the handler socket from the asynchronous state object.
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;
    
        // Read data from the client socket. 
        int bytesRead = handler.EndReceive(ar);
    
        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            // Check for end-of-file tag. If it is not there, read more data.
            content = state.sb.ToString();
    
            this.Invoke(new MethodInvoker(delegate()
            {
                lstListener.Items.Add(content);
            }));
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
    }
