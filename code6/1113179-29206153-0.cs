    while (true) {
      if (isTheFirst) {
        //... omitted for brievety
      } else {
        try {
          ret = mq.Peek(MessageQueue.InfiniteTimeout, cursor, PeekAction.Next);
          Console.WriteLine(ret.Id);
        } catch (MessageQueueException e) {
          if(e.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
		  {
		      Console.WriteLine("Log here that Timeout has occured");
              continue; // will skip Thread.Sleep(1000); and whatever code you put after
		  }
        }
      }
      Thread.Sleep(1000);
    }
