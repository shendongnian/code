        public IMyTask<T> GetTask<T>(T input) where T : IData
        {
            var taskType = typeof(IMyTask<>);
            var inputType = input.GetType();
            var genericType = taskType.MakeGenericType(inputType);
            return (IMyTask<T>)_componentContext.Resolve(genericType);
        }
