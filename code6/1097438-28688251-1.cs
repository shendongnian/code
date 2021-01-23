    public class BusinessEntityValidator : IBusinessValidator<AwesomeBusinessEntity>
    {
       public void Validate(AwesomeBusinessEntity businessEntity)
       {
           if (string.IsNullOrEmpty(businessEntity.Name)
           {
                throw new ArgumentNullException(businessEntity);
            }
      }
