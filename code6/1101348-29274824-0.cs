    var topProducts = m_context.PRODUCTS
        .Join(m_context.PRODUCT_VIEW, product=> product.Id, view => view.ProductId,
            (product, view ) => new { ProductId = product.Id, ViewId = view.Id})
        .GroupBy(g => g.ProductId)
        .Select(s => new {
            Id = s.Key,
            ViewCount= s.Count()
        })
        .OrderByDescending(o => o.ViewCount)
        .Take(5).ToList();
