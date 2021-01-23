    checkedlistbox.DataSource = list;
    checkedlistbox.DisplayMember = "WebsiteName";
    for (int i = 0; i < checkedListbox.Items.Count; ++i) {
      checkedListbox.SetItemChecked(i, ((ACLASS)checkedListbox.Items[i]).IsChecked);
    }
