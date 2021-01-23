    Public Class UIListBox
        Inherits ListBox
        Public Sub New()
            Me.m_stateDisabled = New ItemLayout(Me)
            Me.m_stateEnabled = New ItemLayout(Me)
            Me.m_stateReadOnly = New ItemLayout(Me)
        End Sub
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property StateDisabled() As ItemLayout
            Get
                Return Me.m_stateDisabled
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property StateEnabled() As ItemLayout
            Get
                Return Me.m_stateEnabled
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property StateReadOnly() As ItemLayout
            Get
                Return Me.m_stateReadOnly
            End Get
        End Property
        Friend Sub NotifyStateChanged(source As ItemLayoutColors, propertyName As String)
            Me.Invalidate()
            Debug.WriteLine("UIListBox: State changed.")
        End Sub
        Private m_stateDisabled As ItemLayout
        Private m_stateEnabled As ItemLayout
        Private m_stateReadOnly As ItemLayout
    End Class
    <ToolboxItem(False)>
    Public Class ItemLayout
        Inherits Component
        Public Sub New(listBox As UIListBox)
            Me.m_listBox = listBox
            Me.m_background = New ItemLayoutColors(Me)
            Me.m_foreground = New ItemLayoutColors(Me)
        End Sub
        Friend ReadOnly Property ListBox() As UIListBox
            Get
                Return Me.m_listBox
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Background() As ItemLayoutColors
            Get
                Return Me.m_background
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Foreground() As ItemLayoutColors
            Get
                Return Me.m_foreground
            End Get
        End Property
        Private m_background As ItemLayoutColors
        Private m_foreground As ItemLayoutColors
        Private m_listBox As UIListBox
    End Class
    <ToolboxItem(False)>
    Public Class ItemLayoutColors
        Inherits Component
        Public Sub New(layout As ItemLayout)
            If (layout Is Nothing) Then Throw New ArgumentNullException("layout")
            Me.m_layout = layout
        End Sub
        Friend ReadOnly Property Layout() As ItemLayout
            Get
                Return Me.m_layout
            End Get
        End Property
        Public Property Selected() As Color
            Get
                Return Me.m_selected
            End Get
            Set(value As Color)
                If (value <> Me.m_selected) Then
                    Me.m_selected = value
                    Me.Layout.ListBox.NotifyStateChanged(Me, "Selected")
                End If
            End Set
        End Property
        Public Property Unselected() As Color
            Get
                Return Me.m_unselected
            End Get
            Set(value As Color)
                If (value <> Me.m_unselected) Then
                    Me.m_unselected = value
                    Me.Layout.ListBox.NotifyStateChanged(Me, "Unselected")
                End If
            End Set
        End Property
        Private Function ShouldSerializeSelected() As Boolean
            Return (Me.Selected <> Color.Empty)
        End Function
        Private Function ShouldSerializeUnselected() As Boolean
            Return (Me.Unselected <> Color.Empty)
        End Function
        Private m_selected As Color
        Private m_unselected As Color
        Private m_layout As ItemLayout
    End Class
