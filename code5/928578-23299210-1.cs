        public void GetAverageRequestTimeByPeriod()
        {
            // Firstly project out both the PageHit and the rounded request time
            var averages = _pageHits.Select(t => new { RoundedTime = t.GetRequestTimeToNearest30Mins(), PageHit = t})
                                    // Then Group them all by the rounded time, forming the blocks you mention
                                    .GroupBy(t => t.RoundedTime)
                                    // Project out the block time and the average of each page hit response time in the block
                                    .Select(g => new { RequestTimeBlock = g.Key, AverageResponseTime = g.Average(t => t.PageHit.PageResponseTime)})
                                    .ToArray();
        }
