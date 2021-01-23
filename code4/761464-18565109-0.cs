        public static void AlignSeries(Series seriesA, Series seriesB)
        {
            var aligned = seriesA.Points.GroupJoin(seriesB.Points, a => a.XValue, b => b.XValue, (a, b) => new { a = a, b = b.SingleOrDefault() }).ToArray();
            DataPointCollection bCollection = seriesB.Points;
            bCollection.Clear();
            foreach (var pair in aligned)
            {
                DataPoint bPoint = new DataPoint();
                bPoint.XValue = pair.a.XValue;
                if (null != pair.b)
                {
                    bPoint.YValues = pair.b.YValues;
                }
                else
                {
                    bPoint.IsEmpty = true;
                }
                bCollection.Add(bPoint);
            }
        }
