    public class WqController
    {
        private readonly Queue<ICommand> _queue = new Queue<ICommand>();
        private Task _queueProcessor;
        private ICommand _curCommand;
    
        public void Enqueue(ICommand command)
        {
            _queue.Enqueue(command);
    
            if (_queueProcessor == null) _queueProcessor = ProcessQueue();
        }
    
        private async Task ProcessQueue()
        {
            try
            {
                while (_queue.Count != 0)
                {
                    _curCommand = _queue.Peek();
    
                    try
                    {
                        await Task.Run(() => _curCommand.Execute());
                    }
                    catch (OperationCanceledException)
                    {
                        _curCommand.InvalidateCancellationToken();
                        Console.WriteLine("QUEUE PAUSED");
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("FAILED TO EXECUTE COMMAND");
                    }
                    _queue.Dequeue();
                    if (_curCommand.Cts.Token.IsCancellationRequested) return;
                }
            }
            finally
            {
                _queueProcessor = null;
                _curCommand = null;
            }
        }
    
        public async Task Cancel()
        {
            _curCommand.Cts.Cancel(true);
            await _queueProcessor;
        }
    
        public void Resume()
        {
            _queueProcessor = ProcessQueue();
        }
    }
