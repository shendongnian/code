        public void Test()
        {
            var db = new DbContext();
            // This will automatically do you inner join for you.
            db.TableAs.Include(a => a.TableBs);
        }
