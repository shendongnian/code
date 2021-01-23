    <UniformGrid Columns="5"
                 Rows="3">
        <UniformGrid.Resources>
            <DataTemplate x:Key="MyImageTemplate">
                <DockPanel LastChildFill="True">
                    <TextBlock Text="Image Title"
                               DockPanel.Dock="Bottom"
                               HorizontalAlignment="Center" />
                    <Image Source="pr.png" />
                </DockPanel>
            </DataTemplate>
        </UniformGrid.Resources>
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
        <ContentControl ContentTemplate="{StaticResource MyImageTemplate}" />
    </UniformGrid>
