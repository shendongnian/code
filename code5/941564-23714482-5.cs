        class MyMetafileEditor : UITypeEditor {
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
                using (var dlg = new OpenFileDialog()) {
                    dlg.Filter = "Metafiles (*.wmf, *.emf)|*.wmf;*.emf";
                    if (dlg.ShowDialog() == DialogResult.OK) {
                        value = new List<byte>(System.IO.File.ReadAllBytes(dlg.FileName));
                    }
                }
                return value;                     
            }
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
                return UITypeEditorEditStyle.Modal;
            }
        }
