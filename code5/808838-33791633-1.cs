    ActionConfiguration validate = ModelBuilder.EntityType<TEntity>()
        .Collection.Action("Validate");
    validate.Namespace = "Importation";
    validate.EntityParameter<TEntity>(typeof(TEntity).Name);
    validate.CollectionParameter<string>("UniqueFields");
    validate.Returns<ValidationResult>();
