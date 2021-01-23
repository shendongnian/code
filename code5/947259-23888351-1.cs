    Task _messageLoopTask = null;
    
    async void NewMemberCallback(ConnectionController c, Member m, Stream stream)
    {
        if (_messageLoopTask != null)
        {
            // handle re-entrancy
            MessageBox.Show("Already started!");
            return;
        }
    
        _messageLoopTask = MessageLoop(c, m,stream,cts.Token);
    
        if (OnNewMember!=null) OnNewMember(m);
        
        try
        {
            await _messageLoopTask;
        }
        catch (OperationCanceledException ex)
        {
            // swallow cancelation
        }
        catch (AggregateException ex) 
        { 
            // swallow cancelation
            ex.Handle(ex => ex is OperationCanceledException);
        }
        finally
        {
            _messageLoopTask = null;
        }
    }
