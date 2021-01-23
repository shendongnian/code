    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Csdl;
    IEdmModel model = EdmxReader.Parse(new XmlTextReader(/*stream of your $metadata file*/));
    IEdmEntityType type = model.FindType("organisation");
)
