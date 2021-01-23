        public Byte[] A()
        {
          var task = Task.Run(() => BAsync());
          return task.GetAwaiter().GetResult();
        }
