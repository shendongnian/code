    public void Test()
        {
            Task<SomeClass>[] tasks = new Task<SomeClass>[100];
            for (int i = 0; i < 100; i++)
            {
                tasks[i] = SomeMethod(string.Empty);
            }
        }
        private async Task<SomeClass> SomeMethod(object param)
        {
            return await Task.FromResult<SomeClass>(new SomeClass());
        }
