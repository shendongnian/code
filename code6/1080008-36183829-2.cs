            const string termsAggregation = "device_number";
            const string topHitsAggregation = "top_hits";
            var response = await _elasticsearchClient.Client.SearchAsync<CustomerDeviceModel>(s => s
                .Aggregations(a => a
                    .Terms(termsAggregation, ta => ta
                        .Field(o => o.DeviceNumber)
                        .Size(int.MaxValue)
                        .Aggregations(sa => sa
                            .TopHits(topHitsAggregation, th => th
                                .Size(1)
                                .Sort(x => x.Field(f => f.Modified).Descending())
                            )
                        )
                    )
                )
            );
            if (!response.IsValid)
            {
                throw new ElasticsearchException(response.DebugInformation);
            }
            var results = new List<CustomerDeviceModel>();
            var terms = response.Aggs.Terms(termsAggregation);
            foreach (var bucket in terms.Buckets)
            {
                var hit = bucket.TopHits(topHitsAggregation);
                var device = hit.Documents<CustomerDeviceModel>().First();
                results.Add(device);
            }
