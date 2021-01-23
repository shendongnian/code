    private Dictionary<string, string> getDictionary()
        {
            var tbl1 = new List<DummyModel>() { new DummyModel() { Id = 1, FieldName = "Field1", LabelName = "Label1" }, new DummyModel() { FieldName = "Field2", LabelName = "Label2" } };
            var tbl2 = new List<DummyModel>() { new DummyModel() { Id = 1, FieldName = "Field3", LabelName = "Label3" }, new DummyModel() { FieldName = "Field4", LabelName = "Label4" } };
            var tbl3 = new List<DummyModel>() { new DummyModel() {Id = 1,FieldName = "Field5", LabelName = "Label5" }, new DummyModel() { FieldName = "Field6", LabelName = "Label6" } };
            const int cid = 1;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict = tbl1.Where(a => a.Id == cid)
                .Concat(tbl2.Where(a => a.Id == cid))
                .Concat(tbl3.Where(a => a.Id == cid))
                .ToDictionary(a => a.FieldName, a => a.LabelName);
            return dict;
        }
