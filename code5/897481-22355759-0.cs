    public class MyFunctionsConvetion : IStoreModelConvention<EntityContainer>
    {
        public void Apply(EntityContainer item, DbModel model)
        {
            //Get the Edm Model from the DbModel
            EdmModel storeModel = model.GetStoreModel();
            
            //Delare your parameters name, edm type and mode (You can ignore this if you use a parameter-less function)
            List<FunctionParameter> Parameters = new List<FunctionParameter>();
            Parameters.Add(FunctionParameter.Create("StringValue", GetStorePrimitiveType(model, PrimitiveTypeKind.String), ParameterMode.In));
            //Same thing goes for the return type(s) (Why is it a list? Perhaps you can return tables? I haven't tested however since it is no use to me)
            List<FunctionParameter> ReturnParameters = new List<FunctionParameter>();
            ReturnParameters.Add(FunctionParameter.Create("ReturnValue", GetStorePrimitiveType(model, PrimitiveTypeKind.Decimal), ParameterMode.ReturnValue));
            
            //Create the payload and fill the required information alone with the parameter lists we declared
            EdmFunctionPayload payload = new EdmFunctionPayload();
            payload.IsComposable = true;
            payload.Schema = "dbo";
            payload.StoreFunctionName = "ConvertToDecimal";
            payload.ReturnParameters = ReturnParameters;
            payload.Parameters = Parameters;
            //Create the function with it's payload
            EdmFunction function = EdmFunction.Create("ConvertToDecimal", "MyContext", DataSpace.SSpace, payload, new MetadataProperty[] { });
            //Add it to the model
            storeModel.AddItem(function);
        }
        //Little helper method to get the primitive type based on the database provider
        private EdmType GetStorePrimitiveType(DbModel model, PrimitiveTypeKind typeKind)
        {
            return model
                .ProviderManifest
                .GetStoreType(TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(typeKind)))
                .EdmType;
        }
    }
