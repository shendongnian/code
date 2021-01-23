    @Html.Awe().Grid("grid_Category").Columns(
                        new Column { Name = "ID", Width = 55, Groupable = false, },
                        new Column { Name = "Name" },
                        new Column { Name = "NameDisplay" },
                         new Column { Name = "SortID" },
                        new Column { ClientFormat = editFormat, Width = 48 },
                        new Column { ClientFormat = deleteFormat, Width = 48 }
                    ).Url(Url.Action("GetItemCategories", "Category")).Persistence(Persistence.Session
                    ).Sortable(true
                    ).Groupable(false).SingleColumnSort(true
                    ).ShowGroupedColumn(false
                    ).Height(200
                    ).MinHeight(100
                    ).PageSize(10).Parent("txtTitle", "title")
