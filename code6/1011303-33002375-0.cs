    ''' <summary>
    '''  Set Caret Position to specific location and remove data After given Location
    ''' </summary>
    ''' <param name="MaskedTb"> Masked textbox</param>
    ''' <param name="Loct99">Location (Index) after which remove occured and caret is set</param>
    ''' <remarks></remarks>
    Public Sub FocsToMaskedTb( MaskedTb As MaskedTextBox, ByVal Loct99 As Integer)
        If MaskedTb.Text.Length >= Loct99 Then
            MaskedTb.Text = MaskedTb.Text.Remove(Loct99)
        End If
        MaskedTb.SelectionStart = MaskedTb.MaskedTextProvider.LastAssignedPosition + 1
        '' I am using MaskedTextProvider Property
        '' If there is nothing in TextBox, MaskedTb.MaskedTextProvider.LastAssignedPosition = -1
    End Sub
