    class Abc
    {
        public void Close()
        { }
    }
    interface IClosable
    {
        void Close();
    }
    class AbcClosable : Abc, IClosable
    { }
    class GenClosable<T> where T : IClosable
    { }
