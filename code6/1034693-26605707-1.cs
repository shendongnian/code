    class Test
    {
        private List<BaseDoingThings> stuffToDo = new List<BaseDoingThings>();
        public void AddStuffToDo(BaseDoingThings todo)
        {
            stuffToDo.Add(todo);
        }
        public void Execute()
        {
            foreach(var stuff in stuffToDo)
            {
                stuff.Do();
            }
        }
    }
