    public class TheUserControl : UserControl, IRefreshAble, ICanDeleteItem, IHoldATypedItem 
    {
         public void Refresh()
         {
             //Your refreshcode
         }
         public bool CanDelete {get { /*code that indicates if an item can be deleted*/ } }
         public void Delete(/*parameters ommited*/)
         {
              if(CanDelete)
              {
                 //Delete Item
              }
         }
         public Type TheType { get { return typeOf(Employee); } }
         // otherstuff
    }
