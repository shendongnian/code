        public void SO29343103_UtcDates()
        {
            const string sql = "select @date";
            var date = DateTime.UtcNow;
            var returned = connection.Query<DateTime>(sql, new { date }).Single();
            var delta = returned - date;
            Assert.IsTrue(delta.TotalMilliseconds >= -1 && delta.TotalMilliseconds <= 1);
        }
