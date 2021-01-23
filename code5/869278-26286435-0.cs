        scraper.LinkTo(fetcher, link => link != null);
        scraper.LinkTo(DataflowBlock.NullTarget<Link>());
        scraper.HandleCompletion(fetcher);
        Status.Info.Log("Fetching APOD's archive list");
        links.ForEach(link => scraper.Post(link));
        scraper.Complete();
        try
        {
            await fetcher.Completion;
            Status.Finished.Log("Fetched: {0:N0}, Skipped: {1:N0}, Errors: {2:N0}, Seconds: {3:N2}",
                fetched, skipped, errored, (DateTime.UtcNow - startedOn).TotalMilliseconds / 1000.0);
        }
        catch (AggregateException errors)
        {
            foreach (var error in errors.InnerExceptions)
                Status.Failure.Log(error.Message);
        }
        catch (TaskCanceledException)
        {
            Status.Cancelled.Log("The process was manually cancelled!");
        }
        catch (Exception error)
        {
            Status.Failure.Log(error.Message);
        }
