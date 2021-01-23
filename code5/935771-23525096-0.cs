    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <WrapPanel Grid.IsSharedSizeScope="True">
                <WrapPanel.Resources>
                    <Style TargetType="TextBlock">
                        <Setter Property="Padding" Value="2" />
                        <Setter Property="HorizontalAlignment" Value="Center" />
                    </Style>
                </WrapPanel.Resources>
                <WrapPanel.Children>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="abcdefghijklmnopqrstuvwxyz" />
                    </Grid>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="group1" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="1234567890" />
                    </Grid>
                </WrapPanel.Children>
            </WrapPanel>
        </Grid>
    </Window>
