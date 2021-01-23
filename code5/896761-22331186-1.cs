    public static class FakeService
    {
        public static Person GetPerson(Guid foo, string bar, int baz)
        {
            Person something = new Person{ /*Put nice data here*/ };
            return something;
        }
    }
