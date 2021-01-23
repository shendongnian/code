    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
        var batchAndPage = _context.Set<Sample>()
            .Where(s => s.OrderId == orderId)
            .OrderBy(s => s.Id)
            .BatchesOf(itemsPerPage)
            .Select((b, i) => new { Page = i, Batch = b })
            .FirstOrDefault(e => e.Batch.Any(s => s.Id == sampleId));
        if (batchAndPage == null) return -1;
        return batchAndPage.Page;
    }
