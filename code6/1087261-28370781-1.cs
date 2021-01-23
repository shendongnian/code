    void dgv_EditingControlShowing(object sender,
                                   DataGridViewEditingControlShowingEventArgs e) {
      ComboBox cb = e.Control as ComboBox;
      if (cb != null) {
        cb.DropDownStyle = ComboBoxStyle.DropDown;
      }
    }
