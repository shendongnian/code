    using System;
    using System.Collections.Generic;
    using System.Collections;
    ...
    public class Artical:IEnumerable
    {
    	public Artical()
    	{
    	}
      
          public int Id { get; set;}
          public string Content_Language_en  { get ; set;}
          public string Content_Language_de  { get ; set;}
          public string Content_Language_ru  { get ; set;}
    
          public void ArticalCollection()
          {
              List<Artical> x = new List<Artical>();
          }
    
    
          public List<Artical> List { get; set; }
    
            IEnumerator IEnumerable.GetEnumerator()
          {
              return List.GetEnumerator();
          }
    
    } 
    ...
    
    //----------------------------------------------
    
    List<Artical> lst = new List<Artical>()
                {
                             new Artical{
                             Id=1,
                             Content_Language_en="en-content here1",
                             Content_Language_ru="ru-content here1",
                             Content_Language_de="de-content here1"},
                             
                             new Artical{
                             Id=2,
                             Content_Language_en="en-content here2",
                             Content_Language_ru="ru-content here2",
                             Content_Language_de="de-content here2"}
    
                };
                               
    
            foreach(var item in lst)
            {
                Console.WriteLine("{0} {1} {2} {3}", 
                    item.Id, item.Content_Language_en, item.Content_Language_ru, item.Content_Language_de);
            if  (item.Content_Language_en == "Hello in English" ) 
           
                {
                 // do sometihng 
                }
                if  (item.Content_Language_ru =="Hello in Russian" ) 
        
                {
                 // do sometihng 
                }
