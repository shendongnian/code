    var fooDataTable = new DataTable();
    if (ids.Count > 0)
    {
        fooDataTable.Columns.Add("ID", typeof(int));
        fooDataTable.Columns.Add("CarNumber");
        fooDataTable.Columns.Add("ArriveDate", typeof(DateTime));                
        foreach (var car in ids)
        {
            fooDataTable.Rows.Add(car?.ID, car?.CarNumber, car?.ArriveDate);
        }
    }
    SqlParameter cdIDs = new SqlParameter("@ListToCalc", SqlDbType.Structured);
    cdIDs.Value = fooDataTable;
    cdIDs.TypeName = "tp_CarList";
    var template = new CarFieldsDTO
    {
        Fields = db.Database.SqlQuery<fn_Car_Result>
            ("SELECT * FROM dbo.fn_Car(@ListToCalc)", cdIDs)
                .Select(field => new CarFieldsDTO
                {
                    ID = field.ID,
                    CarNumber = field.CarNumber,
                    ArriveDate = field.ArriveDate,                    
                }).ToList()
    };
    var fields = new List<CarFieldsDTO> { template };
    return fields.AsQueryable();
			
