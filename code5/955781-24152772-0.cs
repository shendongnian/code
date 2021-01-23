            //using Microsoft.Data.Edm
            IEdmModel edmModel = Request.ODataProperties().Model;
            ClrTypeAnnotation annotation = edmModel.GetAnnotationValue<ClrTypeAnnotation>(edmSchemaType);
            if (annotation != null)
            {
                return annotation.ClrType;
            }
