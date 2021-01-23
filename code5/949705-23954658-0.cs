    ''' <summary>
    ''' Collapse XML comment for all code members
    '''</summary>
    Sub CollapseXmlComments()
        Try
            DTE.UndoContext.Open("Collapse XML comments")
     
            Dim ce As CodeElement2
            For Each ce In DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements
                collapseSubmembers(ce, False)
            Next
     
            DTE.UndoContext.Close()
        Catch ex As Exception
            DTE.UndoContext.Close()
        End Try
    End Sub
     
    ''' <summary>
    ''' Toggles the outline of XML comment for all code members.
    '''</summary>
    Sub ToggleXmlComments()
        Try
            DTE.UndoContext.Open("Toggle XML comments outline")
     
            'remember selection
            Dim oldAnchor, oldActive As EnvDTE.TextPoint
            Dim sel As TextSelection = CType(DTE.ActiveDocument.Selection, TextSelection)
            oldAnchor = sel.AnchorPoint.CreateEditPoint
            oldActive = sel.ActivePoint.CreateEditPoint
     
            Dim ce As CodeElement2
            For Each ce In DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements
                collapseSubmembers(ce, True)
            Next
     
            'restore selection
            sel.MoveToAbsoluteOffset(oldAnchor.AbsoluteCharOffset) 'set active point
            sel.SwapAnchor() 'set anchor to active point
            sel.MoveToAbsoluteOffset(oldActive.AbsoluteCharOffset, True)
     
            DTE.UndoContext.Close()
        Catch ex As Exception
            DTE.UndoContext.Close()
        End Try
    End Sub
     
    ''' <summary>Collapses the member and its sub members if any.</summary>
    ''' <param name="ce">The member.</param>
    ''' <param name="toggle">If True, the comment outline is toggled,
    ''' otherwise it is collapsed.</param>
    Private Sub collapseSubmembers(ByVal ce As CodeElement2, ByVal toggle As Boolean)
        Dim memberStart, commentStart, commentEnd As EditPoint2
        Dim comChars As String
     
        Select Case DTE.ActiveDocument.ProjectItem.FileCodeModel.Language
            Case "{B5E9BD33-6D3E-4B5D-925E-8A43B79820B4}"
                'VB
                comChars = "'''"
            Case Else
                'C#
                comChars = "///"
        End Select
     
        Try
            memberStart = ce.GetStartPoint(vsCMPart.vsCMPartWholeWithAttributes).CreateEditPoint
            commentStart = getCommentStart(memberStart.CreateEditPoint, comChars)
            commentEnd = getCommentEnd(commentStart.CreateEditPoint, comChars)
            If toggle Then
                'toggle
                CType(DTE.ActiveDocument.Selection, TextSelection).MoveToPoint(commentStart)
                DTE.ExecuteCommand("Edit.ToggleOutliningExpansion")
            Else
                'collapse
                commentStart.OutlineSection(commentEnd)
            End If
        Catch ex As Exception
        End Try
     
        'try submembers
        If ce.IsCodeType Then
            Dim ce2 As CodeElement2
            For Each ce2 In CType(ce, CodeType).Members
                collapseSubmembers(ce2, toggle)
            Next
        ElseIf ce.Kind = vsCMElement.vsCMElementNamespace Then
            Dim ce2 As CodeElement2
            For Each ce2 In CType(ce, CodeNamespace).Members
                collapseSubmembers(ce2, toggle)
            Next
        End If
    End Sub
     
    ''' <summary>Gets starting point of the comment.</summary>
    ''' <param name="ep">Commented member start point.</param>
    ''' <param name="commentChars">The comment character.
    ''' It is ''' for VB or /// for C#.</param>
    ''' <returns></returns>
    Private Function getCommentStart(ByVal ep As EditPoint2, ByVal commentChars As String) As EditPoint2
        Try
            Dim line, lastCommentLine As String
            ep.StartOfLine()
            ep.CharLeft()
            While Not ep.AtStartOfDocument
                line = ep.GetLines(ep.Line, ep.Line + 1).Trim
                If line.Length = 0 Or line.StartsWith(commentChars) Then
                    If line.Length> 0 Then
                        lastCommentLine = ep.Line
                    End If
                    ep.StartOfLine()
                    ep.CharLeft()
                Else
                    Exit While
                End If
            End While
     
            ep.MoveToLineAndOffset(lastCommentLine, 1)
            While ep.GetText(commentChars.Length) <> commentChars
                ep.CharRight()
            End While
     
            Return ep.CreateEditPoint
        Catch ex As Exception
        End Try
    End Function
     
    ''' <summary>Gets ending point of the comment.</summary>
    ''' <param name="ep">Comment start point.</param>
    ''' <param name="commentChars">The comment character.
    ''' It is ''' for VB or /// for C#.</param>
    ''' <returns></returns>
    Private Function getCommentEnd(ByVal ep As EditPoint2, ByVal commentChars As String) As EditPoint2
        Try
            Dim line As String
            Dim lastCommentPoint As EditPoint
            lastCommentPoint = ep.CreateEditPoint
            ep.EndOfLine()
            ep.CharRight()
            While Not ep.AtEndOfDocument
                line = ep.GetLines(ep.Line, ep.Line + 1).Trim
                If line.StartsWith(commentChars) Then
                    lastCommentPoint = ep.CreateEditPoint
                    ep.EndOfLine()
                    ep.CharRight()
                Else
                    Exit While
                End If
            End While
     
            lastCommentPoint.EndOfLine()
            Return lastCommentPoint
        Catch ex As Exception
        End Try
    End Function
