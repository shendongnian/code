    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Messaging;
    static class MessageQueueHelper
    {
    	private static Dictionary<string, MessageQueue> queues;
    	public static MessageQueue GetPrivateQueueByName(string machinename, string queueName)
    	{
    
    		if (machinename == ".") {
    			machinename = Environment.MachineName;
    		}
    		if (queues == null) {
    			queues = new Dictionary<string, MessageQueue>();
    			try {
    				dynamic qlist = MessageQueue.GetPrivateQueuesByMachine(machinename).ToList;
    				foreach (MessageQueue q in qlist) {
    					queues.Add(q.MachineName.ToLowerInvariant + q.Path.ToLowerInvariant, q);
    				}
    			} catch (Exception ex) {
                    //access denied? server not found?
    				throw new Exception(ex.Message);
    			}
    		}
    
    		string key = string.Format("{0}FormatName:DIRECT=OS:{0}\\private$\\{1}", machinename, queueName).ToLowerInvariant;
    		try {
    			return queues.Item(key);
    		} catch (Exception ex) {
    			return null; //probably key not found
    		}
    
    	}
    
    
    }
