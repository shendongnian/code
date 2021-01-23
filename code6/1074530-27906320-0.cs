    public class MyDataModel
    {
        public string FavouritePet { get; set; }
        public string FavouriteBook { get; set; }
    }
    
    // GET: Home
    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(MyDataModel myData)
    {
        return View();
    }
    
    <button id="btnSubmit" type="button">Submit</button>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script>
        $("#btnSubmit").click(function () {
            var myData = new Object();
            myData.favouritePet = "dog";
            myData.favouriteBook = "What?";
    
            $.ajax({
                url: '@Url.Action("Index", "Home")',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(myData),
                contentType: "application/json; charset=utf-8",
                success: function (){}
            });
        });
    </script>
