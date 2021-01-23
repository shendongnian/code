        [TestMethod()]
        [TestProperty("Anvil.DataSets", "QueryableExtensions")]
        public void DynamicAggregate_test()
        {
            var source = new Anvil.Test.DataSets.TestQueryableDataset();
            var data = source.GetData();
            var expectedTotal = (from d in data select d.Total).Sum();
            var expectedDiscount = (from d in data select d.Discount).Average();
            var expectedCount = (from d in data select d.ID).Count();
            const string prop0 = "Total";
            const string prop1 = "Discount";
            const string prop2 = "ID";
            string sumExpr = string.Format("new ( Sum(it.{0}) as t0, Average(it.{1}) as t1 , Count() as t2)", prop0,prop1, prop2);
            var t = data.GroupBy(x => 1).Select(sumExpr);
            var firstItem = t.Cast<object>().First();
            var ttype = firstItem.GetType();
            var p0 = ttype.GetProperty("t0");
            var p1 = ttype.GetProperty("t1");
            var p2 = ttype.GetProperty("t2");
            decimal actualTotal = (decimal)(p0.GetValue(firstItem));
            decimal actualDiscount = (decimal)(p1.GetValue(firstItem));
            int actualCount = (int)(p2.GetValue(firstItem));
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedDiscount, actualDiscount);
            Assert.AreEqual(expectedCount, actualCount);
        }
