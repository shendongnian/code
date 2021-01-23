    while (socket.Connected) {                
        string row = socket.readLine();
        if (IsControlValid(this)) {
            // Removed String.Copy call, as it was pointless
            BeginInvoke((MethodInvoker)delegate { UpdateForm(row); });
        }
    }
