    public partial class ACRSIEntities : IStoreAcreTransmissionsContext {
         // Implement missing methods
         public void MarkAsModified(AcreReportTransaction item)
         {
           Entry(item).State = EntityState.Modified;
         }
    }
