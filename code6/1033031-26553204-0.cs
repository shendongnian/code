    public class ReportPermissionsById
    {
        public int CwsId { get; set; }
        public string Regions { get; set; }
        public string Reports { get; set; }
    }
    public void BindList()
    {
        var list = LoadData(connString);
        var reportPermissionsById = list
           .GroupBy(r => r.CwsId)
           .Select(r =>
                new ReportPermissionsById
                {
                     CwsId = r.Key,
                     Regions = string.Join(",", r.Select(d => d.Regions)),
                     Reports = string.Join(",", r.Select(d => d.Reports)),
                }
            );
       //Use reportPermissionsById to bind your ListView
    }
