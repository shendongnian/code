    <Window x:Class="AnswerNo1.SolutionA" 
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:System="clr-namespace:System;assembly=mscorlib"
        Title="SolutionA" Height="250" Width="400">
    <Window.Resources>
        <ContextMenu x:Key="ColumnHeaderContextMenuString">
            <MenuItem Header="_Sentence case."/>
            <MenuItem Header="_lowercase"/>
            <MenuItem Header="_UPPERCASE"/>
            <MenuItem Header="_Capitalize Each Word"/>
            <MenuItem Header="_tOGGLE cASE"/>
        </ContextMenu>
        <ContextMenu x:Key="ColumnHeaderContextMenuInt">
            <MenuItem Header="Show _SUM"/>
            <MenuItem Header="Show _Mean"/>
            <MenuItem Header="Show Standard Deviation"/>
            <MenuItem Header="Subtract All Form ..."/>
            <MenuItem Header="Toggle Sign"/>
        </ContextMenu>
        <ContextMenu x:Key="ColumnHeaderContextMenuDateTime">
            <MenuItem Header="Show Time Graph"/>
            <MenuItem Header="Show Minimum Data"/>
            <MenuItem Header="Show Maximum Data"/>
            <MenuItem Header="Show Mode Day"/>
            <MenuItem Header="Sort by day name"/>
        </ContextMenu>
        <Style TargetType="{x:Type DataGridColumnHeader}">
            <Style.Triggers>
                <Trigger Property="Tag" Value="String">
                    <Setter Property="ContextMenu" Value="{StaticResource ColumnHeaderContextMenuString}" />
                </Trigger>
                <Trigger Property="Tag" Value="Int">
                    <Setter Property="ContextMenu" Value="{StaticResource ColumnHeaderContextMenuInt}" />
                </Trigger>
                <Trigger Property="Tag" Value="DateTime">
                    <Setter Property="ContextMenu" Value="{StaticResource ColumnHeaderContextMenuDateTime}" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <DataGrid x:Name="YourDataGrid" AutoGenerateColumns="False" Margin="3">
            <DataGrid.Columns>
                <DataGridTextColumn x:Name="CompanyColumn" Width="*" Binding="{Binding Company}">
                    <DataGridTextColumn.Header>
                        <DataGridColumnHeader Content="Company" Tag="String"/>
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
                <DataGridTextColumn x:Name="ReputationColumn" Width="*" Binding="{Binding Reputation}">
                    <DataGridTextColumn.Header>
                        <DataGridColumnHeader Content="Reputation" Tag="Int"/>
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
                <DataGridTextColumn x:Name="SetupDateColumn" Width="*" Binding="{Binding SetupDate}">
                    <DataGridTextColumn.Header>
                        <DataGridColumnHeader Content="Setup Date" Tag="DateTime"/>
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="auto"/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Label Content="Tag for 1st Column: "/>
            <ComboBox Grid.Column="1" SelectedItem="{Binding Header.Tag, ElementName=CompanyColumn}" >
                <System:String>String</System:String>
                <System:String>Int</System:String>
                <System:String>DateTime</System:String>
            </ComboBox>
        </Grid>
    </Grid>
