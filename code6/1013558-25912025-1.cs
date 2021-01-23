    ContentManager content;
    
    public ContentManager Content 
    {
       get 
       { 
           if(content == null)
              InitialiseContentManager();
           return content;
       }
    }
