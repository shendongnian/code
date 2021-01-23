    public class A
    { 
      // add something usefull
    }
    
    public class B
    {
      // add something usefull
    }
      
    public class CClassModel
    {
      public List<A> m_ItemsA;
      public List<B> m_ItemsB;
    }
    
    public class APlaceHolder
    {
      public string NodeName { get; set; }
      public List<A> Items { get; set; }
    }
    
    public class BPlaceHolder
    {
      public string NodeName { get; set; }
      public List<B> Items { get; set; }
    }
    
    public class CClassViewModel
    {
        CClassModel m_model;
        public ObservableCollection<object> Items { get; set; }
          
        public CClassViewModel()
        {
            m_model = new CClassModel();
            Items = new ObservableCollection<object>;
              
            APlaceHolder aph = new APlaceHolder();
            aph.NodeName = "A Items";
            aph.Items = m_model.m_ItemsA;
            Items.Add(aph);
    
            BPlaceHolder bph = new BPlaceHolder();
            bph.NodeName = "B Items";
            bph.Items = m_model.m_ItemsB;
            Items.Add(bph);
        }
    }
