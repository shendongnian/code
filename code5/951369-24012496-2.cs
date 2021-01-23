    <TabControl x:Name="tab"/>
                        <Button x:Name="button">
                            <i:Interaction.Triggers>
                                <i:EventTrigger SourceName="button" EventName="Click">
                                    <app:MyAction Target="{Binding ElementName=tab}"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </Button>
    Public Class MyAction
        Inherits Interactivity.TriggerAction(Of UIElement)
    
        Protected Overrides Sub Invoke(parameter As Object)
            DirectCast(Target, TabControl).SelectedIndex = 0
        End Sub
    
        Shared Sub New()
            _targetProperty = DependencyProperty.Register(
              "Target",
              GetType(UIElement),
              GetType(MyAction),
              New UIPropertyMetadata(Nothing))
        End Sub
    
        Private Shared _targetProperty As DependencyProperty
        Public Shared ReadOnly Property TargetProperty As DependencyProperty
            Get
                Return _targetProperty
            End Get
        End Property
    
        Property Target As UIElement
            Get
                Return DirectCast(GetValue(TargetProperty), UIElement)
            End Get
            Set(value As UIElement)
                SetValue(TargetProperty, value)
            End Set
        End Property
    
    End Class
