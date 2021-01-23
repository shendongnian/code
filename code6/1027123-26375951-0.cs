        <TabControl Name="ConfigTabs" HorizontalAlignment="Left" VerticalAlignment="Top">
            <TabControl.Resources>
                <Style TargetType="TabItem">
                    <EventSetter Event="Selector.Selected" Handler="OnNewTabSelected"/>
                </Style>
            </TabControl.Resources>
            <TabItem Header="Allgemeines">
            ...           
            </TabItem>
            <TabItem Header="Monitorbelegung">
            ...
            </TabItem>
            <TabItem Header="Produkt-Konfigurationen">
            ...
            </TabItem>
        </TabControl>
