    interface IGenericAction {
        void Do<T>();
    }
    
    class MyGenericListAction : IGenericAction {
        public void Do<T>() {
            Console.WriteLine(new List<T>());
        }
    }
