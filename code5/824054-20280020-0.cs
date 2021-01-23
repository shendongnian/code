    var tableDetails = SFC.Systems_MonitoringMeasurementDetails.Where(
                           y => y.DocNO == DocNum.Text && 
                           y.DetailsDocNum == clsVariable.GetDocNumRecord);
    if(tableDetails.Any())
    {
        SFC.Systems_MonitoringMeasurementDetails.DeleteAllOnSubmit(tableDetails);
    }
                 
