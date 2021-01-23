    namespace WindowsFormsApplication1.soExample
    {
        using System.Collections.Generic;
        public abstract class BaseTabs<TTab, TPage>
            where TTab : BaseTabsTab<TTab, TPage>, new()
            where TPage : BaseTabsTabPage<TTab, TPage>, new()
        {
            private List<TTab> tabs;
            public BaseTabs()
            {
                this.tabs = new List<TTab>();
            }
            public IEnumerable<TPage> Pages
            {
                get
                {
                    foreach (TTab tab in this.Tabs)
                    {
                        yield return tab.Page;
                    }
                }
            }
            public IEnumerable<TTab> Tabs { get { return this.tabs; } }
            public TTab Add()
            {
                TTab tab = new TTab();
                this.tabs.Add(tab);
                return tab;
            }
        }
        public abstract class BaseTabsTab<TTab, TPage>
            where TTab : BaseTabsTab<TTab, TPage>, new()
            where TPage : BaseTabsTabPage<TTab, TPage>, new()
        {
            public BaseTabsTab()
            {
                this.Page = new TPage();
                this.Page.Tab = (TTab)this;
            }
            public TPage Page { get; private set; }
        }
        public abstract class BaseTabsTabPage<TTab, TPage>
            where TTab : BaseTabsTab<TTab, TPage>, new()
            where TPage : BaseTabsTabPage<TTab, TPage>, new()
        {
            public BaseTabsTabPage()
            {
            }
            public TTab Tab { get; internal set; }
        }
        public class DefaultTab : BaseTabsTab<DefaultTab, DefaultTabPage> { }
        public class DefaultTabPage : BaseTabsTabPage<DefaultTab, DefaultTabPage> { }
        public class DefaultTabs : BaseTabs<DefaultTab, DefaultTabPage> { }
    }
