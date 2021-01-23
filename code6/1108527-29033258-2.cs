     <cntrls:ExtendedTreeView ItemsSource="{Binding countryReportsHierarchy}" SelectedItem_="{Binding SelectedArticleTitle, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" >                       
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="SelectedItemChanged">
                                <i:InvokeCommandAction Command="{Binding ArticleCategoryTitleSelectionChangedCommand}" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                        <TreeView.Resources>
                            <HierarchicalDataTemplate  DataType="{x:Type t:CountryReportsHierarchy}"
                                    ItemsSource="{Binding ArticleCategoriesHierarchyCollection}">
                                <TextBlock Text="{Binding Name}" />
                            </HierarchicalDataTemplate>
                            <HierarchicalDataTemplate  DataType="{x:Type t:ArticleCategoriesHierarchy}"
                                    ItemsSource="{Binding ArticleTypesHierarchyCollection}">
                                <TextBlock Text="{Binding Name}"/>
                            </HierarchicalDataTemplate>
                            <DataTemplate  DataType="{x:Type t:ArticleTypesHierarchy}">                              
                                <TextBlock Text="{Binding Name}" />                  
                            </DataTemplate>
                        </TreeView.Resources>
                    </cntrls:ExtendedTreeView>
