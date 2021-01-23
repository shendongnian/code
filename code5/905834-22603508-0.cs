            var products = _unitOfWork.ProductRepository.Get(filter: p => p.Name.StartsWith("S"));
            var orders = _unitOfWork.OrderRepository.Get(filter: o => o.Status == "Status");
            
            var joinList = from product in products
                join order in orders on product.Id equals order.ProudctId into g
                from sub in g.DefaultIfEmpty()
                select new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Count = (sub == null ? 0 : 1)
                };
            var productDtoList = from j in joinList
                group j by new {j.Name, j.Description}
                into g
                select new ProductDto()
                {
                    Name = g.Key.Name,
                    Description = g.Key.Description,
                    NumPendingOrders = g.Sum(p => p.Count)
                };
