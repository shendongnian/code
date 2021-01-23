    @Html.Grid(Model.Item2).Named("ViewEntries").Columns(columns =>
                        {
                            columns.Add(c => c.entryName).Titled("Entry Name").Sortable(true).Filterable(true);
                            columns.Add(c => c.entryDate).Titled("Date").Sortable(true);
                            columns.Add(c => c.entryDetails).Titled("Details").Sortable(true);
                            columns.Add().Titled("Name1").RenderValueAs(c => Name1((int)c.name1)).Sortable(true).Filterable(true);
                            columns.Add().Titled("Name2").RenderValueAs(c => Name2((int)c.name2)).Sortable(true).Filterable(true);
                            columns.Add().Titled("Name3").RenderValueAs(c => Name3((int)c.name3)).Sortable(true).Filterable(true);
                        }).WithPaging(10).Sortable(true).Filterable(true).WithMultipleFilters()
