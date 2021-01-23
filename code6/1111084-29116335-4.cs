    public async Task Start(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await this.acceptCount.WaitAsync(token).ConfigureAwait(false);
            if (token.IsCancellationRequested)
                break;
            var args = new SocketAsyncEventArgs();
            args.UserToken = new SocketFrame
                                 {
                                     CancellationToken = token,
                                     Buffer = null,
                                     Message = null,
                                 };
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            // How do I manage this additional task?
            args.Completed += (s, e) => {
                switch (e.SocketError) {
                    case SocketError.Success:
                        tcs.SetResult(null);
                        break;
                    default:
                        tcs.SetException(new SocketException());
                        break;
                }
            };
 
            if (!this.socket.AcceptAsync(args)) {
                // receiving a true value here 
                // only means that AcceptAsync
                // started successfully
                // we still need to 
                // "await for the Completed event handler"
                await tcs.Task; // this will automatically throw
                                // if tcs.SetException(...) was used
                // also, it will return null if all is well
                // but most importantly, it will allow us to 
                // know when to call the next method
                await this.AcceptInbound(this.socket, args);
            }
        }
    }
