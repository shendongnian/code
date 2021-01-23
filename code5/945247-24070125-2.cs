    class CustomizedDropDownEditor : RadDropDownListEditor
    {
        public override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Left || e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                //Customized left right arrow key behaviour
                int selectionStart = ((RadDropDownListEditorElement)this.EditorElement).SelectionStart;
                int selectionLength = ((RadDropDownListEditorElement)this.EditorElement).SelectionLength;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
    
