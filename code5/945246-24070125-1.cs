    private void RadGridView1_OnMouseLeave(object sender, EventArgs e)
    {
        int selectionStart = ((RadDropDownListEditorElement)((CustomizedDropDownEditor)radGridView1.ActiveEditor).EditorElement).SelectionStart;
    }
    
