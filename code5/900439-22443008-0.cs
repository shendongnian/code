    for (int i = 0; i < FolderGridView.Rows.Count; i++){
        CheckBox chk = (CheckBox)FolderGridView.Rows[i].FindControl("FolderCheckBox");
        if (chk.Checked == true){
           foreach (Control ctl in FolderGridView.Rows(i).Cells(1).Controls) {
	           if (ctl is LinkButton) {
		       string filename = ((LinkButton)ctl).Text;
	           }
        }
    }
