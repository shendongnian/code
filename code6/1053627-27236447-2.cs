    #Region " Option Statements "
    
    Option Explicit On
    Option Strict On
    Option Infer Off
    
    #End Region
    
    #Region " Imports "
    
    Imports System.ComponentModel
    
    #End Region
    
    ''' <summary>
    ''' A custom <see cref="ComboBox"/> user control.
    ''' </summary>
    Public Class ElektroComboBox : Inherits ComboBox
    
    #Region " Properties "
    
        ''' <summary>
        ''' Gets or sets the border color.
        ''' </summary>
        ''' <value>The border color.</value>
        <Category("Appearance")>
        Public Property BorderColor() As Color
            Get
                Return borderColor1
            End Get
            Set(ByVal value As Color)
                Me.borderColor1 = value
                Me.Invalidate()
            End Set
        End Property
        ''' <summary>
        ''' The border color.
        ''' </summary>
        Private borderColor1 As Color = SystemColors.ControlDark
    
        ''' <summary>
        ''' Gets or sets the border style.
        ''' </summary>
        ''' <value>The border color.</value>
        <Category("Appearance")>
        Public Property BorderStyle As ButtonBorderStyle
            Get
                Return borderStyle1
            End Get
            Set(ByVal value As ButtonBorderStyle)
                Me.borderStyle1 = value
                Me.Invalidate()
            End Set
        End Property
        ''' <summary>
        ''' The border style.
        ''' </summary>
        Private borderStyle1 As ButtonBorderStyle = ButtonBorderStyle.Solid
    
    #End Region
    
    #Region " Enumerations "
    
        ''' <summary>
        ''' Specifies a Windows Message.
        ''' </summary>
        Private Enum WindowsMessages
    
            WM_PAINT = &HF
    
        End Enum
    
    #End Region
    
    #Region " Windows Procedure "
    
        ''' <summary>
        ''' Processes Windows messages.
        ''' </summary>
        ''' <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
        Protected Overrides Sub WndProc(ByRef m As Message)
    
            MyBase.WndProc(m)
    
            Select Case m.Msg
    
                Case WindowsMessages.WM_PAINT
                    Me.DrawBorder()
    
            End Select
    
        End Sub
    
    #End Region
    
    #Region " Private Methods "
    
        ''' <summary>
        ''' Draws a border on the control surface.
        ''' </summary>
        Private Sub DrawBorder()
    
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
    
                ControlPaint.DrawBorder(Graphics.FromHwnd(Me.Handle), Me.ClientRectangle, Me.borderColor1, Me.borderStyle1)
    
            End Using
    
        End Sub
    
    #End Region
    
    End Class
