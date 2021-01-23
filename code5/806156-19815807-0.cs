    foreach (Message msg in msgs)
    {
       foreach (MessageQueue s in queueArray)
       {
          if (s.Id == oInQueue.Id) continue; // Skip if this is the originator
          c.WriteMessage(s, msg, msg.Label);
       }
    }
