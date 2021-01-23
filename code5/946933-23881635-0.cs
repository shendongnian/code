    void view_ShownEditor(object sender, DevExpress.Xpf.Grid.EditorEventArgs e) {
        if (e.Column.FieldName == "CODE_MAT") {
            var cmbmat = (ComboBoxEdit)e.Editor;
            // do something (e.g. subscribe events)
        }
    }
