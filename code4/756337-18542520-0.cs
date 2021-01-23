    Task<Answer> ReceiveAnswerAsync(int uniqueId)
    {
        var block = new BufferBlock<Answer>();
        _inputAnswers.LinkTo(
            block,
            new DataflowLinkOptions { MaxMessages = 1, PropagateCompletion = true },
            answer => answer.Id == uniqueId);
        return block.ReceiveAsync();
    }
