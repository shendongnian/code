    namespace Company.MyModule {
        public class TileSortAdminMenu : INavigationProvider {
            private Localizer T { get; set; }
            public string MenuName { get { return "admin"; } }
            public void GetNavigation(NavigationBuilder builder) {
                builder
                    .AddImageSet("mymodule")
                    .Add(T("My Module"), "5", menu => menu
                        .LinkToFirstChild(true)
                        .Add(T("Content Item 1"), "1", item => item
                            .LocalNav()
                            .LinkToFirstChild(true)
                            .Add(T("Tab 1"), "1", tab => tab
                                .LocalNav()
                                .Action("Index", "MyModuleAdmin", new { area = "Company.MyModule"})
                            )
                            .Add(T("Tab 2"), "2", tab => tab
                                .LocalNav()
                                .Action("Tab2", "MyModuleAdmin", new { area = "Company.MyModule"})
                            )
                        )
                        .Add(T("Content Item 2"), "2", item => item
                            .LocalNav()
                            .LinkToFirstChild(true)
                            .Add(T("Tab 1"), "1", tab => tab
                                .LocalNav()
                                .Action("ContentItem2Tab1", "MyModuleAdmin", new { area = "Company.MyModule"})
                            )
                            .Add(T("Tab 2"), "2", tab => tab
                                .LocalNav()
                                .Action("ContentItem2Tab2", "MyModuleAdmin", new { area = "Company.MyModule"})
                            )
                        )
                    );
            }
        }
    }
