    public class SagaDataSnatcher : IStoreSagaData
    {
         public SagaDataSnatcher(IStoreSagaData innerSagaPersister) {
             this.innerSagaPersister = innerSagaPersister;
         }
         public void Insert(ISagaData data, string[] sagaDataPropertyPathsToIndex) {
             innerSagaPersister.Insert(data, sagaDataPropertyPathsToIndex);
             SnatchIt(data);
         }
         public void Update(ISagaData data, string[] sagaDataPropertyPathsToIndex) {
             innerSagaPersister.Update(data, sagaDataPropertyPathsToIndex);             
             SnatchIt(data);
         }
         void SnatchIt(ISagaData data) {
             MessageContext.GetCurrent().Items["my-secret-key"] = data;
         }
         // other ISagaData members down here, just delegate to inner
    }
