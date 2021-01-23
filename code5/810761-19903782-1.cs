    <Style TargetType="{x:Type local:ItemPresenter">
      <Setter Property="EndDate" Value="{Binding EndDate, RelativeSource={RelativeSource FindAncestor, AncestorType=local:Presenter}" />
    </Style>
    <Style TargetType="{x:Type local:Presenter}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:Presenter}">
                    <ItemsControl ItemsSource="{TemplateBinding ItemsSource}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <ContentControl Content="{Binding}">
                                    <ContentControl.Resources>
                                        <!-- more Typed DataTemplates -->
                                        <DataTemplate DataType="{x:Type item:ItemSubProjects}">
                                            <local:ItemPresenter />
                                        </DataTemplate>
                                    </ContentControl.Resources>
                                </ContentControl>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
