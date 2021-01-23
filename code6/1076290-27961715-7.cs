    public static void acceptCallback(IAsyncResult ar) {
        // Get the socket that handles the client request.
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
        // Signal the main thread to continue.
        allDone.Set();
        // Create the state object.
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(AsynchronousSocketListener.readCallback), state);
    }
