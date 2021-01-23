    private void myGrid_CellEditorInitialized(objec sender, GridViewCellEventArgs e)
    {
                    RadTextBoxEditor radTextBoxEditor = e.ActiveEditor as RadTextBoxEditor;
                    RadTextBoxEditorElement editorElement = radTextBoxEditor.EditorElement as RadTextBoxEditorElement;
                    editorElement.AutoToolTip = true;  
                    TextBox myTextBox= (TextBox)editorElement.TextBoxItem.HostedControl;  
    
                    myTextBox.MouseMove -= new MouseEventHandler(textBox_MouseMove);  
                    myTextBox.MouseLeave -= new EventHandler(textBox_MouseLeave); 
                    myTextBox.MouseMove += new MouseEventHandler(textBox_MouseMove);  
                    myTextBox.MouseLeave += new EventHandler(textBox_MouseLeave);  
    }
