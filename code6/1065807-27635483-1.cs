    var query = from n in GetNames()
                join e in GetMailingAddress()
                on n.Id equals e.Id
                select new {n.Id,n.Name,e.Email };
    foreach (var item in query)
        {
            Console.WriteLine(item.Id + "-" + item.Name +"-"+ item.Email);
        }
