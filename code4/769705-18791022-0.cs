    MQQueueManager qMgr = null;
    MQQueue queue = null;
    int openOptions = MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING + MQC.MQOO_INQUIRE;
    
    try
    {
       qMgr = new MQQueueManager(qMgrName);
       System.Console.Out.WriteLine("Successfully connected to " + qMgrName);
    
       queue = qMgr.AccessQueue(qName, openOptions, null, null, null);
       System.Console.Out.WriteLine("Successfully opened " + qName);
    
       System.Console.Out.WriteLine("Current queue depth is " + queue.CurrentDepth);
    }
    catch (MQException mqex)
    {
       System.Console.Out.WriteLine("Exception CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
    }
    catch (System.IO.IOException ioex)
    {
       System.Console.Out.WriteLine("Exception ioex=" + ioex);
    }
    finally
    {
       try
       {
          if (queue !=null)
          {
             queue.Close();
             System.Console.Out.WriteLine("Successfully closed " + qName);
          }
    
       }
       catch (MQException mqex)
       {
          System.Console.Out.WriteLine("Exception on close CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
       }
       try
       {
          if (qMgr !=null)
          {
             qMgr.Disconnect();
             System.Console.Out.WriteLine("Disconnected from " + qMgrName);
          }
       }
       catch (MQException mqex)
       {
          System.Console.Out.WriteLine("Exception on disconnect CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
       }
    }
