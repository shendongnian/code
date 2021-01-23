    public class ConvertToFullOperationCreator : OperationCreatorBase
    {        
        private Func<OperationsFactory> get_operationsFactory;
        private SomeHelper m_someHelper;
        
        public ConvertToFullOperationCreator(
                IKernel container)
        {
           this.get_operationsFactory = () => container.Resolve<OperationsFactory>;
           m_someHelper = container.Resolve<SomeHelper>();
        }
        public override List<OperationBase> CreateOperation(FileData fileData)
        {
              var m_operationsFactory = get_operationsFactory()
              // Here you can place all your code
              var creator1 = m_operationsFactory
                    .GetCreator(OperationType.SomeSuboperation1);
              ...
              var creator2 = m_operationsFactory
                    .GetCreator(OperationType.SomeSuboperation2);
              ...
          }
    }
