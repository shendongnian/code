    #Region " Option Statements "
    
    Option Explicit On
    Option Strict On
    Option Infer Off
    
    #End Region
    
    #Region " Imports "
    
    Imports System.ComponentModel
    
    #End Region
    
    #Region " ElektroGroupBox "
    
    ''' <summary>
    ''' A custom <see cref="GroupBox"/> user control.
    ''' </summary>
    Public Class ElektroGroupBox : Inherits GroupBox
    
    #Region " Properties "
    
        ''' <summary>
        ''' Gets or sets the border color.
        ''' </summary>
        ''' <value>The border color.</value>
        <Category("Appearance")>
        Public Property BorderColor As Color
            Get
                Return Me.borderColor1
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
    
    #Region " Events "
    
        ''' <summary>
        ''' Handles the <see cref="E:Paint"/> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:PaintEventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    
            '  MyBase.OnPaint(e)
            Me.DrawBorder(e)
    
        End Sub
    
    #End Region
    
    #Region " Private Methods "
    
        ''' <summary>
        ''' Draws a border on the control surface.
        ''' </summary>
        Private Sub DrawBorder(ByVal e As PaintEventArgs)
    
            ' The groupbox header text size.
            Dim textSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
    
            ' The width of the blankspace drawn at the right side of the text.
            Dim blankWidthSpace As Integer = 3
    
            ' The thex horizontal offset.
            Dim textOffset As Integer = 7
    
            ' The rectangle where to draw the border.
            Dim borderRect As Rectangle = e.ClipRectangle
            With borderRect
                .Y = .Y + (textSize.Height \ 2)
                .Height = .Height - (textSize.Height \ 2)
            End With
    
            ' The rectangle where to draw the header text.
            Dim textRect As Rectangle = e.ClipRectangle
            With textRect
                .X = .X + textOffset
                .Width = (textSize.Width - blankWidthSpace)
                .Height = textSize.Height
            End With
    
            ' Draw the border.
            ControlPaint.DrawBorder(e.Graphics, borderRect, Me.borderColor1, Me.borderStyle1)
    
            ' Fill the text rectangle.
            e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
    
            ' Draw the text on the text rectangle.
            textRect.Width = textSize.Width + (blankWidthSpace * 2) ' Fix the right side space.
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
    
        End Sub
    
    #End Region
    
    End Class
    
    #End Region
