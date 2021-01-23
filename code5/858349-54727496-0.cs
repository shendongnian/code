    Public Module Extensions
            ''' <summary>Sets Enabled property on most controls, set AutoCheck property on CheckBox controls, and ignores GroupBox and Label controls if Enabled parameter equals False.</summary>
            ''' <remarks>Purpose: Disabled GroupBox, Label, and CheckBox controls have Black ForeColor when disabled, making it difficult or impossible to read if background is dark color.</remarks>
            ''' <example>Instead of Panel1.Enabled=False, use Panel1.Controls.SetEnabled(Enabled:=False)</example>
            <Extension()>
            Public Sub SetEnabled(ByRef Controls As System.Windows.Forms.Control.ControlCollection, ByVal Enabled As Boolean, Optional ByVal Recursive As Boolean = True)
                For Each c As Control In Controls
                    If Enabled = False Then
                        ' Do not disable some controls such as group boxes
                        Select Case c.GetType
                            Case GetType(GroupBox), GetType(Label)
                                ' Do nothing to control
                            Case GetType(CheckBox)
                                ' Change AutoCheck property instead
                                DirectCast(c, CheckBox).AutoCheck = False
                            Case Else
                                ' Disable control
                                c.Enabled = False
                        End Select
                    Else
                        Select Case c.GetType
                            Case GetType(CheckBox)
                                ' Set Enabled and AutoCheck properties to true for CheckBox controls
                                With DirectCast(c, CheckBox)
                                    .AutoCheck = True
                                    .Enabled = True
                                End With
                            Case Else
                                ' Enable all other Controls
                                c.Enabled = True
                        End Select
                    End If
        
                    If Recursive = True AndAlso c.Controls IsNot Nothing AndAlso c.Controls.Count > 0 Then
                        c.Controls.SetEnabled(Enabled, Recursive)
                    End If
                Next
            End Sub
    End Module
