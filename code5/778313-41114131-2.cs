    public async Task<ActionResult> MyReallySlowReport(CancellationToken cancellationToken)
        {
            CancellationToken disconnectedToken = Response.ClientDisconnectedToken;
            using (var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, disconnectedToken))
            {
                List<ReportItem> items;
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    items = await context.ReportItems.ToListAsync(source.Token);
                }
                return View(items);
            }
        }
