    var messageXml = from messages in dbContext.Messages
                               join transactions in dbContext.Transactions
                               on messages.TransactionID equals transactions.TransactionID 
                               where transactions.CreatedOn >= StartDate
                               && transactions.CreatedOn <= EndDate
                               select messages.MessageXML;
    var messages = from m in messageXml select XElement.Parse(m);
    
    var ids = (from msg in messages
                let id = msg.Attribute("IDThatIWant")
                where !String.IsNullOrEmpty(id) 
                select Convert.ToInt32(id)).ToList<int>();
