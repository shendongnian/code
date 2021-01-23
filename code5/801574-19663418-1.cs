    class TestSystemDbSet : TestDbSet<Models.System>
    {
        public override Models.System Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(s => s.Id == id);
        }
    }
