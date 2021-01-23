    /// <summary>
    /// Callback for changes to the Text property
    /// </summary>
    private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TextBox textBox = (TextBox)d;
        bool inReentrantChange = false;
        int savedCaretIndex = 0;
        if (textBox._isInsideTextContentChange)
        {
            // Ignore property changes that originate from OnTextContainerChanged,
            // unless they contain a different value (indicating that a
            // re-entrant call changed the value)
            if (textBox._newTextValue != DependencyProperty.UnsetValue)
            {
                // OnTextContainerChanged calls
                //      SetCurrentDeferredValue(TextProperty, deferredTextReference)
                // Usually the DeferredTextReference will appear in the new entry
                if (textBox._newTextValue is DeferredTextReference)
                {
                    if (e.NewEntry.IsDeferredReference &&
                        e.NewEntry.IsCoercedWithCurrentValue &&
                        e.NewEntry.ModifiedValue.CoercedValue == textBox._newTextValue)
                    {
                        return;
                    }
                }
                // but if the Text property is data-bound, the deferred reference
                // gets converted to a real string;  during the conversion (in
                // DeferredTextReference.GetValue), the TextBox updates _newTextValue
                // to be the string.
                else if (e.NewEntry.IsExpression)
                {
                    object newValue = e.NewEntry.IsCoercedWithCurrentValue
                                        ? e.NewEntry.ModifiedValue.CoercedValue
                                        : e.NewEntry.ModifiedValue.ExpressionValue;
                    if (newValue == textBox._newTextValue)
                    {
                        return;
                    }
                }
            }
            // If we get this far, we're being called re-entrantly with a value
            // different from the one set by OnTextContainerChanged.  We should
            // honor this new value.
            inReentrantChange = true;
            savedCaretIndex = textBox.CaretIndex;
        }
        // CoerceText will have already converted null -> String.Empty,
        // but our default CoerceValueCallback could be overridden by a
        // derived class.  So check again here.
        string newText = (string)e.NewValue;
        if (newText == null)
        {
            newText = String.Empty;
        }
        textBox._isInsideTextContentChange = true;
        try
        {
            using (textBox.TextSelectionInternal.DeclareChangeBlock())
            {
                // Update the text content with new TextProperty value.
                textBox.TextContainer.DeleteContentInternal((TextPointer)textBox.TextContainer.Start, (TextPointer)textBox.TextContainer.End);
                textBox.TextContainer.End.InsertTextInRun(newText);
                // Collapse selection to the beginning of a text box
                textBox.Select(savedCaretIndex, 0);
            }
        }
        finally
        {
            //
            if (!inReentrantChange)
            {
                textBox._isInsideTextContentChange = false;
            }
        }
        // We need to clear undo stack in case when the value comes from
        // databinding or some other expression.
        if (textBox.HasExpression(textBox.LookupEntry(TextBox.TextProperty.GlobalIndex), TextBox.TextProperty))
        {
            UndoManager undoManager = textBox.TextEditor._GetUndoManager();
            if (undoManager != null)
            {
                if (undoManager.IsEnabled)
                    undoManager.Clear();
            }
        }
    }
