            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                response = state.sb.ToString();
                if (response.IndexOf("<EOF>") != -1)
                {
                    state.sb.Clear();
                    receiveDone.Set();
                }
                else
                {
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
            }
