                <ListView.View>
                    <GridView x:Name="gridView">
                        <GridViewColumn Width="50" Header="PEC" x:Name="PrisEnCompte" DisplayMemberBinding="{Binding Path=Flag, Converter={StaticResource BooleanConverter}}" />
                        <GridViewColumn Width="80" Header="PMID" x:Name="PMRQ" DisplayMemberBinding="{Binding Path=Pmid}"/>
                        <GridViewColumn Width="40" Header="Ligne" x:Name="Ligne" DisplayMemberBinding="{Binding Path=Ligne}"/>
                        <GridViewColumn Width="250" Header="Libellé PMRQ" x:Name="LibellePMRQ" DisplayMemberBinding="{Binding Path=LibellePmrq}">
                            <GridViewColumn.HeaderContainerStyle>
                                <Style TargetType="GridViewColumnHeader" BasedOn="{StaticResource {x:Type GridViewColumnHeader}}">
                                    <Setter Property="ToolTip" Value="{Binding LibellePmrq}"></Setter>
                                </Style>
                            </GridViewColumn.HeaderContainerStyle>
                        </GridViewColumn>
                        <GridViewColumn Width="80" Header="OTM" x:Name="OTM" DisplayMemberBinding="{Binding Path=Otm}"/>
                        <GridViewColumn Width="45" Header="TOTM" x:Name="TOTM" DisplayMemberBinding="{Binding Path=Totm}"/>
                        <GridViewColumn Width="250" Header="Libellé TOTM" x:Name="LibelleTOTM" DisplayMemberBinding="{Binding Path=LibelleTotm}">
                            <GridViewColumn.HeaderContainerStyle>
                                <Style TargetType="GridViewColumnHeader" BasedOn="{StaticResource {x:Type GridViewColumnHeader}}">
                                    <Setter Property="ToolTip" Value="{Binding LibelleTotm}"></Setter>
                                </Style>
                            </GridViewColumn.HeaderContainerStyle>
                        </GridViewColumn>
                        <GridViewColumn Width="65" Header="GA" x:Name="GA" DisplayMemberBinding="{Binding Path=GroupeAlerte}"/>
                        <GridViewColumn Width="65" Header="Discipline" x:Name="Discipline" DisplayMemberBinding="{Binding Path=Discipline}"/>
                        <GridViewColumn Width="120" Header="Discipline Substituée" x:Name="DisciplineSubstituee" DisplayMemberBinding="{Binding Path=DisciplineSubstituee}"/>
                        <GridViewColumn Width="70" Header="Remarque" x:Name="Remarque" DisplayMemberBinding="{Binding Path=Remarque}"/>
                    </GridView>
                </ListView.View>
            </ListView>
