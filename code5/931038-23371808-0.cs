    orderMessageEmail.MessageChain = DbContext.Current
        .Messages
        .Where(c => 
            c.OrderId == orderMessageEmail.OrderId && 
            c.IsPublic && 
            c.MessageId != orderMessageEmail.MessageId && 
            c.MessageId < orderMessageEmail.MessageId
        )
        .OrderByDescending(c => c.MessageId)
        .Take(10)
        .Select(c => new {
            c, u = c.User, cap = c.CustomerAccountPerson
        }). 
        .AsEnumerable()
        .Select(c => new OrderMessageChain()
        {
            CreateDateTime = c.c.CreateDateTime,
            MessageId = c.c.MessageId,
            Message = c.c.MessageData,
            UserFirstName = c.u == null ? "" : c.u.FirstName,
            UserLastName = c.u == null ? "" : c.u.LastName,
            CustomerFirstName = c.cap == null ? "" : c.cap.FirstName,
            CustomerLastName = c.cap == null ? "" : c.cap.LastName,
            SentFrom = c.c.SentFrom
        })
        .ToList();
