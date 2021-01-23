 async Task<long> JobRunner(CancellationToken token, long taskId)
 {
            try
            {
                token.ThrowIfCancellationRequested();
                IMessageReader reader = this.GetMessageReader(taskId);
                Interlocked.CompareExchange(ref this._primaryReader, reader, null);
                try
                {
                    MessageReaderResult readerResult = new MessageReaderResult() { IsRemoved = false, IsWorkDone = false };
                    bool loopAgain = false;
                    do
                    {
                        readerResult = await reader.TryProcessMessage(token).ConfigureAwait(false);
                        loopAgain = !readerResult.IsRemoved && !token.IsCancellationRequested;
                        // the task is rescheduled to the threadpool which allows other scheduled tasks to be processed
                        // otherwise it could use exclusively the threadpool thread
                        if (loopAgain)
                           await Task.Yield();
                    } while (loopAgain);
                }
                finally
                {
                    Interlocked.CompareExchange(ref this._primaryReader, null, reader);
                }
            }
            catch (OperationCanceledException)
            {
                // NOOP
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {
                this._ExitTask(taskId);
            }
            return taskId;
}
