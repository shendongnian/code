    void MainFormGridView_CellEditorInitialized(object sender, GridViewCellEventArgs e)
    {
                if (e.ActiveEditor is customAutoCompleteBox)
                {
                    customAutoCompleteBox editor = (customAutoCompleteBox)e.ActiveEditor;
                    RadAutoCompleteBoxElement element = (RadAutoCompleteBoxElement)editor.EditorElement;
                    element.Delimiter = '\t';
                    element.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    element.AutoCompleteDisplayMember = e.Column.Name;
                    element.AutoCompleteValueMember = e.Column.Name;
                    element.AutoCompleteDataSource = (from c in entity.myOffer
                                                      orderby c.customer
                                                      where c.customer!= null
                                                      select c.customer)
                                                        .Distinct()
                                                        .ToList();
                }
    }
