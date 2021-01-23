    @{
        ViewBag.Title = "Index";
    }
    
    @using (Html.BeginForm("fibonacci", "Home", FormMethod.Post))
    {
        <p>Enter a number</p> @Html.TextBox("Input")
        <br />
        <input type="Submit" id="btnsubmit" value="Check" />
    }
 
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult fibonacci(int Input)
    {
        if (Input > 1)
        {
           int a = 0;
	       int b = 1;
	       // In N steps compute Fibonacci sequence iteratively.
           for (int i = 0; i < Input; i++)
	       {
	           int temp = a;
	           a = b;
	           b = temp + b;
               Response.Write("<p>fibonacci series " + b.ToString() + "</p>");
           }        
          return View("Index");
        }
        return View("Index");
    }
    }
