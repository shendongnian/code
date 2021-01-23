            public IEnumerable<Aggregate> GetOrders(ODataQueryOptions<ReportingOrder> opts, [FromUri(Name="$groupby")]string groupby, [FromUri(Name="$aggregates")]string aggregates = null)
            {
                var url = opts.Request.RequestUri.AbsoluteUri;
                
                
                int? top = null;
    
                if (opts.Top != null)
                {
                    top = int.Parse(opts.Top.RawValue);
    
                    var topStr = string.Format("$top={0}", top.Value);
                    url = url.Replace(topStr, "");
                    var req = new HttpRequestMessage(HttpMethod.Get, url);
    
                    opts = new ODataQueryOptions<ReportingOrder>(opts.Context, req);
    
                }
                
                var query = opts.ApplyTo(db.ReportingOrders.AsQueryable()) as IQueryable<ReportingOrder>;
    
                var results = query.GroupBy(groupby, aggregates, top);
                
                return results;
            }
