	public dynamic newGet(string type)
    {
	   dynamic item = null;
       switch (type)
       {
          case "Text":
            item = "ABC";
            break;
          case "Number":
            item = 1;
            break;
       }
       return item;
    }
