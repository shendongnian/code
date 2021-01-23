    IQueryAble<PageData> q = datamodel.VW_WaypointDetails.AsEnumerable()
                             .Select(wpd=> new PageData 
                                             {
                                                Name = wpd.Name,
                                                SurName = wpd.Surname,
                                                Description = wpd.Description, 
                                                Barcode = wpd.Barcode == null ? StartBarCode : wpd.Barcode
                                                }).AsQueryAble();
