    interface IAssemblyLineItem
    {
        void Execute();
    }
    class AssemblyLineService
    {
        public void ExecuteAll(IEnumerable<IAssemblyLineItem> items)
        {
            foreach (var item in items)
            {
                item.Execute();
            }
        }
    }
