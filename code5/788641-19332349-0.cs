    public class DefaultAutiableConvention: IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Name == "CreatedBy" || instance.Name == "CreatedOn")
            {
                instance.Generated.Insert();
            }
            else if (instance.Name == "ModifiedBy" || instance.Name == "ModifiedOn")
            {
                instance.Generated.Always();
            }
        }
    }
