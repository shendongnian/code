    public class CompanyContainerMap : ClassMap<CompanyContainer>
    {
        public CompanyContainerMap()
        {
            Table("S1073_CODE");
            Id(x => x.Id).Column("CODE_ID");
            DynamicComponent(p => p.Values, m =>
            {
                for(var index = 0; index < GeneratedColumns.ColumnsInfo.Length; index++)
                {
                    m.Map(GeneratedColumns.ColumnsInfo[index])
                        .CustomSqlType(GeneratedColumns.ColumnSqlTypes[index])
                        .CustomType(GeneratedColumns.ColumnTypes[index]);
                }
            });
        }
    }
