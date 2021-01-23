     // Deletes the data values in the LINQ to SQL generated class.
        public virtual bool Delete(T Item)
        {
            using (TestDBContext db = new TestDBContext())
            {
                db.GetTable<T>().DeleteOnSubmit(Item);
                db.SubmitChanges();
                return true;
            }
        }
