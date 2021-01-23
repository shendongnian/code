        public IMyTask GetTask<T>(T input) where T : IData
        {
            var taskType = typeof(IMyTask<>);
            var inputType = input.GetType();
            var genericType = taskType.MakeGenericType(inputType);
            return (IMyTask)_componentContext.Resolve(genericType);
        }
