        var msg = new Message()
        {
            MessageId = new Guid(),
            Author = user,
            Body = body,
            SendTime = DateTimeOffset.UtcNow,
            PadId = new Guid(pad_id)
        };
        // pad.Messages.Add(msg); // don't need this.
        db.Messages.Add(msg);
