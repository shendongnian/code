     public void SaveCreatedMessage(Message message)
        {
            var dbEntry = _context.Message.Add(message);
            if (dbEntry != null)
            {
                // Create the new record
                dbEntry.CustomerID = message.CustomerID;
                dbEntry.MessageID = message.MessageID;
                dbEntry.Description = message.Description;
                dbEntry.Text = message.Text;
                dbEntry.IsRead = message.IsRead;
                dbEntry.CreatedOn = message.CreatedOn;
                dbEntry.CreatedBy = message.CreatedBy;
            
                _context.Message.Add(message);
            }
            _context.SaveChanges();
        }
