     public class item()
           {
           private string name;
           private string background;
           public string Name
         {
        get
         {
        return this.name;
         }
        set 
        {
        this.name= value;
       }
      }
       public string BackgroundColor
       {
       get
       {
        return this.background;
       }
       set 
       {
        this.background= value;
    }
    }
      List<item> Itemlist= new List<item>()
          for(int i=0;i<Itemlist.Count;i++)
              {
         Itemlist[i].BackgroundColor=Colorsarray[i];
             }
       SampleList.ItemSource=Itemlist;
        In xaml 
        Background="{Binding BackgroundColor}"
      
      
