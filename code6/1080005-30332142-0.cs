            const string aggName = "LocationIDAgg";
            const string aggNameTopHits = "LatestForLoc";
            var response = await ElasticClient.SearchAsync<PlacementVerificationES>(s => s
                .Query(BuildQuery(filter, null))                
                .Size(int.MaxValue)
                .Aggregations(a=> a
                    .Terms(aggName, t=> t
                        .Field(f=>f.LocationID)
                        .Size(100)
                        .Aggregations(innerAgg => innerAgg
                            .TopHits(aggNameTopHits, th=> th
                                .Size(1)
                                .Sort(x=>x.OnField(f=> f.Date).Descending())
                            )
                        )
                    )
                )
            ).VerifySuccessfulResponse();
            //var debug = response.GetRequestString();
            var agBucket = (Bucket)response.Aggregations[aggName];
            var output = new List<PlacementVerificationForReporting>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once PossibleInvalidCastExceptionInForeachLoop
            foreach (KeyItem i in agBucket.Items)
            {
                var topHits = (TopHitsMetric)i.Aggregations[aggNameTopHits];
                var top1 = topHits.Hits<PlacementVerificationES>().Single();
                var reportingObject = RepoToReporting(top1);
                output.Add(reportingObject);
            }
            return output;
