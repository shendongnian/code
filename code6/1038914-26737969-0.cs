           public class LinkList
           {
              private Link list = null; //default value – empty list
    
    	      private numberOfItems = 0;
       
              public void AddItem(int item) //add item to front of list
              {
                  list = new Link(item, list);
    	          numberOfItems++;
              }
    
              public void DisplayItems() // Displays items in list
              {
                  Link temp = list;
                  while (temp != null)
                  {
                      Console.WriteLine(temp.Data);
                      temp = temp.Next;
                  }
    
              }
    
              public int NumberOfItems
              {
                
                  get {return numberOfItems; }
    	
              }
    
          }
