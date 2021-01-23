    Imports System.Collections.Generic
    Imports System.ComponentModel
    Imports System.Drawing
    Imports System.Linq
    Imports System.Linq.Expressions
    Imports System.Windows.Forms
    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim testbox As New AutoCompleteComboBox.SuggestComboBox
            Me.Controls.Add(testbox)
            testbox.DataSource = New List(Of String) From {"Janean Mcgaha", "Tama Gaitan", "Jacque Tinnin", "Elvira Woolfolk", "Fransisca Owens", "Minnie Ardoin", _
            "Renay Bentler", "Joye Boyter", "Jaime Flannery", "Maryland Arai", "Walton Edelstein", "Nereida Storrs", _
            "Theron Zinn", "Katharyn Estrella", "Alline Dubin", "Edra Bhatti", "Willa Jeppson", "Chelsea Revel", _
            "Sonya Lowy", "Danelle Kapoor"}
        End Sub
    End Class
    
    Namespace AutoCompleteComboBox
        Public Class SuggestComboBox
            Inherits ComboBox
    #Region "fields and properties"
    
            Private ReadOnly _suggLb As New ListBox() With {.Visible = False, .TabStop = False}
            Private ReadOnly _suggBindingList As New BindingList(Of String)()
            Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
            Private _propertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
            Private _filterRule As Expression(Of Func(Of String, String, Boolean))
            Private _filterRuleCompiled As Func(Of String, Boolean)
            Private _suggestListOrderRule As Expression(Of Func(Of String, String))
            Private _suggestListOrderRuleCompiled As Func(Of String, String)
    
            Public Property SuggestBoxHeight() As Integer
                Get
                    Return _suggLb.Height
                End Get
                Set(value As Integer)
                    If value > 0 Then
                        _suggLb.Height = value
                    End If
                End Set
            End Property
    
            ''' <summary>
            ''' If the item-type of the ComboBox is not string,
            ''' you can set here which property should be used
            ''' </summary>
            Public Property PropertySelector() As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
                Get
                    Return _propertySelector
                End Get
                Set(value As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String))))
                    If value Is Nothing Then
                        Return
                    End If
                    _propertySelector = value
                    _propertySelectorCompiled = value.Compile()
                End Set
            End Property
    
            '''<summary>
            ''' Lambda-Expression to determine the suggested items
            ''' (as Expression here because simple lamda (func) is not serializable)
            ''' <para>default: case-insensitive contains search</para>
            ''' <para>1st string: list item</para>
            ''' <para>2nd string: typed text</para>
            '''</summary>
            Public Property FilterRule() As Expression(Of Func(Of String, String, Boolean))
                Get
                    Return _filterRule
                End Get
                Set(value As Expression(Of Func(Of String, String, Boolean)))
                    If value Is Nothing Then
                        Return
                    End If
                    _filterRule = value
                    _filterRuleCompiled = Function(item) value.Compile()(item, Text)
                End Set
            End Property
    
            '''<summary>
            ''' Lambda-Expression to order the suggested items
            ''' (as Expression here because simple lamda (func) is not serializable)
            ''' <para>default: alphabetic ordering</para>
            '''</summary>
            Public Property SuggestListOrderRule() As Expression(Of Func(Of String, String))
                Get
                    Return _suggestListOrderRule
                End Get
                Set(value As Expression(Of Func(Of String, String)))
                    If value Is Nothing Then
                        Return
                    End If
                    _suggestListOrderRule = value
                    _suggestListOrderRuleCompiled = value.Compile()
                End Set
            End Property
    
    #End Region
    
            ''' <summary>
            ''' ctor
            ''' </summary>
            Public Sub New()
                ' set the standard rules:
                _filterRuleCompiled = Function(s) s.ToLower().Contains(Text.Trim().ToLower())
                _suggestListOrderRuleCompiled = Function(s) s
                _propertySelectorCompiled = Function(collection) collection.Cast(Of String)()
    
                _suggLb.DataSource = _suggBindingList
                AddHandler _suggLb.Click, AddressOf SuggLbOnClick
    
                AddHandler ParentChanged, AddressOf OnParentChanged
            End Sub
    
            ''' <summary>
            ''' the magic happens here ;-)
            ''' </summary>
            ''' <param name="e"></param>
            Protected Overrides Sub OnTextChanged(e As EventArgs)
                MyBase.OnTextChanged(e)
    
                If Not Focused Then
                    Return
                End If
    
                _suggBindingList.Clear()
                _suggBindingList.RaiseListChangedEvents = False
                _propertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggBindingList.Add)
                _suggBindingList.RaiseListChangedEvents = True
                _suggBindingList.ResetBindings()
    
                _suggLb.Visible = _suggBindingList.Any()
    
                If _suggBindingList.Count = 1 AndAlso _suggBindingList.[Single]().Length = Text.Trim().Length Then
                    Text = _suggBindingList.[Single]()
                    [Select](0, Text.Length)
                    _suggLb.Visible = False
                End If
            End Sub
    
    #Region "size and position of suggest box"
    
            ''' <summary>
            ''' suggest-ListBox is added to parent control
            ''' (in ctor parent isn't already assigned)
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <param name="e"></param>
            Private Overloads Sub OnParentChanged(sender As Object, e As EventArgs)
                Parent.Controls.Add(_suggLb)
                Parent.Controls.SetChildIndex(_suggLb, 0)
                _suggLb.Top = Top + Height - 3
                _suggLb.Left = Left + 3
                _suggLb.Width = Width - 20
                _suggLb.Font = New Font("Segoe UI", 9)
            End Sub
    
            Protected Overrides Sub OnLocationChanged(e As EventArgs)
                MyBase.OnLocationChanged(e)
                _suggLb.Top = Top + Height - 3
                _suggLb.Left = Left + 3
            End Sub
    
            Protected Overrides Sub OnSizeChanged(e As EventArgs)
                MyBase.OnSizeChanged(e)
                _suggLb.Width = Width - 20
            End Sub
    
    #End Region
    
    #Region "visibility of suggest box"
    
            Protected Overrides Sub OnLostFocus(e As EventArgs)
                ' _suggLb can only getting focused by clicking (because TabStop is off)
                ' --> click-eventhandler 'SuggLbOnClick' is called
                If Not _suggLb.Focused Then
                    HideSuggBox()
                End If
                MyBase.OnLostFocus(e)
            End Sub
    
            Private Sub SuggLbOnClick(sender As Object, eventArgs As EventArgs)
                Text = _suggLb.Text
                Focus()
            End Sub
    
            Private Sub HideSuggBox()
                _suggLb.Visible = False
            End Sub
    
            Protected Overrides Sub OnDropDown(e As EventArgs)
                HideSuggBox()
                MyBase.OnDropDown(e)
            End Sub
    
    #End Region
    
    #Region "keystroke events"
    
            ''' <summary>
            ''' if the suggest-ListBox is visible some keystrokes
            ''' should behave in a custom way
            ''' </summary>
            ''' <param name="e"></param>
            Protected Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
                If Not _suggLb.Visible Then
                    MyBase.OnPreviewKeyDown(e)
                    Return
                End If
    
                Select Case e.KeyCode
                    Case Keys.Down
                        If _suggLb.SelectedIndex < _suggBindingList.Count - 1 Then
                            _suggLb.SelectedIndex += 1
                        End If
                        Return
                    Case Keys.Up
                        If _suggLb.SelectedIndex > 0 Then
                            _suggLb.SelectedIndex -= 1
                        End If
                        Return
                    Case Keys.Enter
                        Text = _suggLb.Text
                        [Select](0, Text.Length)
                        _suggLb.Visible = False
                        Return
                    Case Keys.Escape
                        HideSuggBox()
                        Return
                End Select
    
                MyBase.OnPreviewKeyDown(e)
            End Sub
    
            Private Shared ReadOnly KeysToHandle As List(Of Keys) = New List(Of Keys) From {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}
            Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
                ' the keysstrokes of our interest should not be processed be base class:
                If _suggLb.Visible AndAlso KeysToHandle.Contains(keyData) Then
                    Return True
                End If
                Return MyBase.ProcessCmdKey(msg, keyData)
            End Function
    
    #End Region
        End Class
    End Namespace
    
