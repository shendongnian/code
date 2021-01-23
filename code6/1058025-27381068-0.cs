    Public Class UIListBox
        Inherits ListBox
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
        Private m_stateDisabled As New ItemLayout
        Private m_stateEnabled As New ItemLayout
        Private m_stateReadOnly As New ItemLayout
    End Class
    Public Class ItemLayoutColors
        Inherits Component
        Public Property Selected() As Color
        Public Property Unselected() As Color
        Private Function ShouldSerializeSelected() As Boolean
            Return (Me.Selected <> Color.Empty)
        End Function
        Private Function ShouldSerializeUnselected() As Boolean
            Return (Me.Unselected <> Color.Empty)
        End Function
    End Class
    Public Class ItemLayout
        Inherits Component
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
        Private m_background As New ItemLayoutColors
        Private m_foreground As New ItemLayoutColors
    End Class
