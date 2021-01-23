    this.sampleCollection = your collection/List;
    this.OnPropertyChange("SampleCollection");
    
    this.xdgSample.FieldLayouts[0].SortedFields.Add(new FieldSortDescription
                            {
                                IsGroupBy = true,
                                Field = this.xamInputList.FieldLayouts[0].Fields["field2"],
                                Direction = System.ComponentModel.ListSortDirection.Ascending
                            });
    
                            this.xdgSample.FieldLayoutSettings.HeaderPlacement = HeaderPlacement.OnTopOnly;
                            this.xdgSample.FieldLayoutSettings.HeaderPlacementInGroupBy = HeaderPlacementInGroupBy.WithDataRecords;
