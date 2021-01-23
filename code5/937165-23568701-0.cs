        public HttpResponseMessage GetOrder()
        {
            // Sample object data
            Order order = new Order();
            order.Id = "A100";
            order.OrderedDate = DateTime.Now;
            order.OrderTotal = 150.00;
       
            // Explicitly override content negotiation and return XML
            HttpResponseMessage<Order> response = new HttpResponseMessage<Order>(order, 
                        new MediaTypeHeaderValue("application/xml"));
            return response;
        }
