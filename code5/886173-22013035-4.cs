    interface FooProcessor<T>
    {
    }
    interface Foo<T>
    {
        void Process(FooProcessor<T> processor);
    }
    class FooChild : Foo<FooChild>
    {
        void Foo<FooChild>.Process(FooProcessor<FooChild> processor)
        {
            this.Process((FooProcessorFooChild)processor);
        }
        protected void Process(FooProcessorFooChild processor)
        {
        }
    }
    class FooProcessorFooChild : FooProcessor<FooChild>
    {
    }
