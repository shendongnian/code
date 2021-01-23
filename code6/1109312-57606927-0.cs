    public async Task Execute(IList<TDest> outRows ,CancellationToken stoppingToken)
            {
                var mapping = _destCtx.Model.FindEntityType(typeof(TDest)).Relational();
                var strategy = _destCtx.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var tran = _destCtx.Database.BeginTransaction())
                    {
                        try
                        {
                            //var dest = _destCtx.Set<TDest>();
                            //dest.RemoveRange(dest);
                            await _destCtx.Database.ExecuteSqlCommandAsync((string)$"TRUNCATE TABLE {mapping.Schema}.{mapping.TableName}");
                            //await _destCtx.BulkDeleteAsync(dest, null, stoppingToken);
                            //dest.AddRange(outRows);
                            await _destCtx.BulkInsertAsync(outRows, null, stoppingToken);
    
                            //await _destCtx.SaveChangesAsync(stoppingToken);
    
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                });
            }
        }
