    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Paragraph p = new Paragraph();
        // Add the new Paragraph to the RichTextBox flowdocument.
        rtb1.Document.Blocks.Add(p);
        // Create the first Run.
        Run r1 = new Run("This is a ");
        // Create the second Run.
        Run r2 = new Run("test");
        r2.TextDecorations = TextDecorations.Underline;
        // Add the new Runs to the Paragraph.
        p.Inlines.Add(r1);
        p.Inlines.Add(r2);
        // Create a new Run. This will be placed between r1 and r2.
        Run newRun = new Run();
        // Copy the formatting from r1 to our new Run.
        CopyInlineFormattingToRun(r1, ref newRun);
        // Set the text of the new Run to be a space.
        newRun.Text = " ";
        // Place our new Run after r1.
        CreateNewRunAfterExistingRun(r1, newRun);
        // Put the caret at the start of newRun.
        rtb1.CaretPosition = newRun.ContentStart;
        // Remove the space at the end of newRun.
        newRun.ContentEnd.DeleteTextInRun(-1);
        // Give focus to the RichTextBox.
        rtb1.Focus();
    }
    /// <summary>
    /// Copies some of the properties in <paramref name="mainInline"/> to <paramref name="receiverRun"/>.
    /// </summary>
    /// <param name="mainInline">The <see cref="Inline"/> containing the desired formatting.</param>
    /// <param name="receiverRun">The <see cref="Run"/> which should receive the formattinh from <paramref name="mainInline"/>.</param>
    internal static void CopyInlineFormattingToRun(Inline mainInline, ref Run receiverRun)
    {
        receiverRun.FontFamily = mainInline.FontFamily;
        receiverRun.FontSize = mainInline.FontSize;
        receiverRun.FontStretch = mainInline.FontStretch;
        receiverRun.FontStyle = mainInline.FontStyle;
        receiverRun.FontWeight = mainInline.FontWeight;
        receiverRun.Foreground = mainInline.Foreground;
        receiverRun.Background = mainInline.Background;
        receiverRun.TextDecorations = mainInline.TextDecorations;
    }
    /// <summary>
    /// Places a <see cref="Run"/> after an existing <see cref="Run"/>.
    /// </summary>
    /// <param name="existingRun">The existing <see cref="Run"/> already present in the <see cref="FlowDocument"/>.</param>
    /// <param name="newRun">The new <see cref="Run"/> which will be placed after the <paramref name="existingRun"/> in the <see cref="FlowDocument"/>.</param>
    private void CreateNewRunAfterExistingRun(Run existingRun, Run newRun)
    {
        Paragraph p = (Paragraph)existingRun.Parent;
        p.Inlines.InsertAfter(existingRun, newRun);
    }
