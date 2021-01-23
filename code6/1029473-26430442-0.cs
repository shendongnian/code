    protected override void OnPreRender(EventArgs e) {
         base.OnPreRender(e);
         DatePicker1.Value = string.Join(",", (GetDateParameters().ToList().ToArray()));
     }
     private IEnumerable < string > GetDateParameters() {
         // I'm assuming report view control id as reportViewer
         foreach(ReportParameterInfo info in ReportViewer1.ServerReport.GetParameters()) {
             if (info.DataType == ParameterDataType.DateTime) {
                 yield return string.Format("[{0}]", info.Prompt);
             }
         }
     }
