    public class MyController
    { 
        public ActionResult MyView(){
            var vm = new MyViewModel();
            vm.MyObjectAsJsonString = GetMyJsonString();
            return View(vm);
        }
        public string GetMyJsonString(){
             return ""; //get your json 
        }
    }
    public class MyViewModel
    {
        public string MyObjectAsJsonString{ get; set; }
    }
    @model MyViewModel
    <script>
      var myObj = json.parse('@Model.MyObjectAsJsonString');
    </script>
