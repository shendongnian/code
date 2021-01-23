    public static void ChecaCheckBoxes(this Panel b, bool checkStatus = true) {
        var listaCheckBoxs = b.Controls
            .OfType<CheckBox>().Where(c => c.Name != "CKB_ancora").ToList();
        listaCheckBoxs.ForEach(
            i => {
                i.Checked = checkStatus;
            });
    }
