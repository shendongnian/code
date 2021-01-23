    public class Example<TTab, TPage>  // 'TPage' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'TPage' in the generic type or method 'ExtendTabs.soExample.Tab<TPage>'
            where TTab : Tab<TPage>, new() 
            where TPage : TabPage<TTab>, new() //new() is provided here as a means to indicate constraint
        {
            private List<TTab> tabs;
    
            public Example()
            {
                this.tabs = new List<TTab>();
    
                this.tabs.Add(new TTab());
            }
        }
