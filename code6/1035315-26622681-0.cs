     from ord in order
        group ord by new
        {
            ord.PostCode,
            ord.Country,
            ord.UserID,
            ord.Email,
            ord.OrderID
        } into gr
        select new 
        {
            OrderID = gr.Key.OrderID,
            UserID = gr.Key.UserID,
            Email = gr.Key.Email,
            PostCode=gr.key.PostCode,
            Country=gr.key.Country,
            ChildrenFields = gr.ToList()
        };
