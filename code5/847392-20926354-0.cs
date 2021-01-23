    <TabControl SelectedIndex="{Binding TabSelectedIndex}">
            <TabItem Header="abc">
                <Button Content="ok"/>
            </TabItem>
            <TabItem Header="xyz" Visibility="{Binding TabVisibility}">
                <Button Content="ok"/>
            </TabItem>
            <TabItem Header="pqr" Visibility="{Binding TabVisibility}">
                <Button Content="ok"/>
            </TabItem>
        </TabControl>
