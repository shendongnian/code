     <Popup IsOpen="{Binding IsOpen}" Height="{Binding Height}" Width="{Binding Width}">
        <Grid>
            <Grid.Resources>
                <DataTemplate x:Key="View1Template">
                    <View:View1/>
                </DataTemplate>
                <DataTemplate x:Key="View2Template">
                    <View:View2/>
                </DataTemplate>
                <DataTemplate x:Key="View3Template">
                    <View:View3/>
                </DataTemplate>
                <DataTemplate x:Key="View4Template">
                    <View:View4/>
                </DataTemplate>
                <DataTemplate x:Key="View5Template">
                    <Design:View5/>
                </DataTemplate>
                <Style x:Key="ContentStyle" TargetType="{x:Type ContentControl}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=TemplateToUse}" Value="View1">
                            <Setter Property="ContentTemplate" Value="{StaticResource View1Template}" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=TemplateToUse}" Value="View2">
                            <Setter Property="ContentTemplate" Value="{StaticResource View2Template}" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=TemplateToUse}" Value="View3">
                            <Setter Property="ContentTemplate" Value="{StaticResource View3Template}" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=TemplateToUse}" Value="View4">
                            <Setter Property="ContentTemplate" Value="{StaticResource View4Template}" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=TemplateToUse}" Value="View5">
                            <Setter Property="ContentTemplate" Value="{StaticResource View5Template}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
           </Grid.Resources>
           
           <ContentControl x:Name="CP" Loaded="CP_Loaded" Style="{StaticResource ContentStyle}" Content="{Binding}" />
        </Grid>
    </Popup>
