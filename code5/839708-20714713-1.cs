        public Rdl.TableType CreateTableExcel()
        {
            Rdl.TableType table = new Rdl.TableType();
            table.Name = "Table1";
            table.Items = new object[]
                {
                    CreateTableColumns(),
                    CreateHeader(),
                    CreateDetails(),
                    CreateTableGroups(),
                };
            table.ItemsElementName = new Rdl.ItemsChoiceType21[]
                {
                    Rdl.ItemsChoiceType21.TableColumns,
                    Rdl.ItemsChoiceType21.Header,
                    Rdl.ItemsChoiceType21.Details,
                    Rdl.ItemsChoiceType21.TableGroups,
                };
            return table;
        }
        private Rdl.TableGroupsType CreateTableGroups()
        {
            Rdl.TableGroupsType tableGroups = new Rdl.TableGroupsType();
            tableGroups.TableGroup = new TableGroupType[]
            {
                CreateTableGroup(),
            };
            return tableGroups;
        }
        private Rdl.TableGroupType CreateTableGroup()
        {
            Rdl.TableGroupType tableGroup = new TableGroupType();
            tableGroup.Items = new object[]
            {
                CreateGrouping(),
            };
            return tableGroup;
        }
        private Rdl.GroupingType CreateGrouping()
        {
            Rdl.GroupingType groupingType = new GroupingType();
            groupingType.Name = "pagebreak";
            groupingType.Items = new object[]
            {
                true,
                CreateGroupExpressions(),
            };
            groupingType.ItemsElementName = new ItemsChoiceType17[]
            {
                ItemsChoiceType17.PageBreakAtEnd,
                ItemsChoiceType17.GroupExpressions
            };
            return groupingType;
        }
        private Rdl.GroupExpressionsType CreateGroupExpressions()
        {
            Rdl.GroupExpressionsType groupExpressions = new GroupExpressionsType();
            groupExpressions.GroupExpression = new string[] { "=Int((RowNumber(Nothing)-1)/65000)" };
            return groupExpressions;
        }
