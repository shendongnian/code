    protected override void Execute(NativeActivityContext context) {
      DataSet dataset = GetDataSet.Get(context);
      foreach(DataTable dt in dataset.Tables) {
        foreach(DataRow row in dt.Rows) {
          row["USER_COMMENT"] = String.IsNullOrEmpty(row["USER_COMMENT"].ToString()) ? "NO DATA" : row["USER_COMMENT"];
        }
      }
      TransformResult.Set(context, dataset);
    }
