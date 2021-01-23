     <TabControl ItemsSource="{Binding Datas.titles}">
     public partial class Window1 : MetroWindow
    {
    
        public Window1()
        {
            init();
        }
    
        private void init()
        {
            Datas = new Datas();
            this.DataContext = this;
        }
    
         public Datas Datas{get;set;}
    }
