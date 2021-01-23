       class Test
        {
            public BinaryWriter Content { get; private set; }
            public Test Write<T>(T data)
            {
                Content.Write((dynamic)data);
                return this;
            }
        }
