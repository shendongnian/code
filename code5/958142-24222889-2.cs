     if (AutoGenerateColumns == true) {
                if (ColumnsGeneratorInternal is GridViewColumnsGenerator) {
                    ((GridViewColumnsGenerator)ColumnsGeneratorInternal).DataItem = dataSource;
                    ((GridViewColumnsGenerator)ColumnsGeneratorInternal).InDataBinding = useDataSource;
                }
                fieldsArray.AddRange(ColumnsGeneratorInternal.GenerateFields(this));
            }
