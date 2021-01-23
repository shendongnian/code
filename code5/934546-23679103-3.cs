    void textBox_MouseMove(object sender, MouseEventArgs e)  
    { 
        if (mousePos != e.Location)  
        { 
            RadTextBoxEditor radTextBoxEditor = this.myGrid.ActiveEditor as RadTextBoxEditor;
            GridDataCellElement gridCellElement = radTextBoxEditor.OwnerElement as GridDataCellElement;
            if (gridCellElement != null && gridCellElement.ContainsErrors)
            {
                RadTextBoxEditorElement radTextBoxEditorElement = radTextBoxEditor.EditorElement as RadTextBoxEditorElement;
                TextBox myTextBox = (TextBox)radTextBoxEditorElement.TextBoxItem.HostedControl;  
                _tooltip.Show(gridCellElement.RowInfo.Cells[gridCellElement.ColumnInfo.Name].ErrorText, myTextBox, new Point(e.Location.X + 8, e.Location.Y + 8));  
                _mouse = e.Location;  
            }
        }
    }
