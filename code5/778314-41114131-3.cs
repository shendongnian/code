    public async Task<ActionResult> MyReallySlowReport(CancellationToken cancellationToken)
    {
        CancellationToken disconnectedToken = Response.ClientDisconnectedToken;
        using (var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, disconnectedToken))
        {
            IEnumerable<ReportItem> items;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                items = await context.ReportItems.ToArrayAsync(source.Token);
            }
            return View(items);
        }
    }
