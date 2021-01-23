    void Application_Start(object sender, EventArgs e)
    {
     // Code that runs on application startup
      RouteTable.Routes.MapPageRoute("StoreRoute","Products/{ProductNumber}","~/Webpages/BookStore/ViewBookDemo.aspx");
    } 
    int productnumber = Convert.ToInt(Page.RouteData.Values["ProductNumber"]);
    if (productnumber  != null)
    {
        if (ProductNumber == 1)
        {
            Image1.ImageUrl = "~/images/css.jpg";
        }
        else if (productnumber == 2)
        {
            Image1.ImageUrl = "~/images/django.jpg";
        }
        else if (productnumber == 3)
        {
            Image1.ImageUrl = "~/images/iphone.jpg";
        }
        else if (productnumber  == 4)
        {
            Image1.ImageUrl = "~/images/Linq.jpg";
        }
      }         
    }
