    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ListBox x:Name="list" Height="90" AllowDrop="True" MouseMove="ListBox_MouseMove" Drop="list_Drop" DragEnter="list_DragEnter" DragLeave="list_DragLeave" PreviewDragOver="list_DragOver">
            <ContentControl>
                Item 1
            </ContentControl>
            <ContentControl>
                Item 2
            </ContentControl>
            <ContentControl>
                Item 3
            </ContentControl>
            <ContentControl>
                Item 4
            </ContentControl>
            <ContentControl>
                Item 5
            </ContentControl>
            <ContentControl>
                Item 6
            </ContentControl>
            <ContentControl>
                Item 7
            </ContentControl>
            <ContentControl>
                Item 8
            </ContentControl>
            <ContentControl>
                Item 9
            </ContentControl>
        </ListBox>
    </Grid>
