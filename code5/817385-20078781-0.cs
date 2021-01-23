     XmlDocument myXmlDoc = new XmlDocument();
     myXmlDoc.Load(@"c:\books.xml"); //wich is above you can use uri location
     XmlNodeList list = myXmlDoc.SelectNodes("/bookstore/book");
      //Selecting all book nodes then extract title author year  
      foreach (XmlNode mynode in list)
      {
      Console.WriteLine(mynode["title"].InnerText);
      Console.WriteLine(mynode["author"].InnerText);
      Console.WriteLine(mynode["year"].InnerText);
      Console.WriteLine(mynode["price"].InnerText);
      Console.WriteLine("------------");
      }
      //OUTPUT :
      Everyday Italian
      Giada De Laurentiis
      2005
      30.00
      -----------------------
      Harry Potter
      J K. Rowling
      2005
      29.99
      -----------------------
      //get the value of `lang` from `title` and `version` from `year` :
       foreach (XmlNode mynode in list)
       {
           Console.WriteLine(mynode["title"].Attributes["lang"].Value );
	  Console.WriteLine(mynode["year"].Attributes["version"].Value );
	 Console.WriteLine("------------");
            }
	//OUTPUT : 
			
      en
      3.5
      ----------------
      fr
      2.0
      //get books that have category="children" and print all both firstane lastname .....
      XmlNodeList list = myXmlDoc.SelectNodes("/bookstore/book[@category='children']");
        foreach (XmlNode mynode in list)
          {
       Console.WriteLine(mynode["title"].InnerText );
       Console.WriteLine(mynode["author"].InnerText);
        Console.WriteLine(mynode["price"].InnerText);
            }
			
	//OUTPUT:
    Harry Potter
    J K. Rowling
    29.99
    //select books where the `lang` of `title` is `en`
     XmlNodeList list = myXmlDoc.SelectNodes("/bookstore/book/title[@lang='en']");
                  foreach (XmlNode mynode in list)
            {
                Console.WriteLine(mynode.ParentNode["title"].InnerText );
                Console.WriteLine(mynode.ParentNode["author"].InnerText);
                Console.WriteLine(mynode.ParentNode["price"].InnerText);
            }
	    //OUTPUT:
			
	    Everyday Italian
            Giada De Laurentiis
            30.00
			
