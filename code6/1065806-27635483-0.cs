    var query = GetNames().Join(GetMailingAddress(),
                                        n => n.Id,
                                        e => e.Id,
                                        (n, e) => new { n.Id,n.Name,e.Email});
            foreach (var item in query)
            {
                Console.WriteLine(item.Id + "-" + item.Name +"-"+ item.Email);
            }
