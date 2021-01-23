    public class MyClass
    {
        public int Id { get; set; }
        public int MyNumber { get; set; }
    }
    public class RequestViewModel
    {
        public List<MyClass> MyClasses { get; set; }
        public int AnotherNumber { get; set; }
    }
    [HttpPost]
    public ActionResult Save(RequestViewModel actionRequestX)
    {
            return null;
    }
    var actionRequest = {
            MyClasses: [
                {
                    Id: 1,
                    MyNumber: 30
                },
                {
                    Id: 2,
                    MyNumber: 40
                }
            ],
            AnotherNumber: 12
        };
        $.ajax({
        type: "POST",
        url: "/Home/Save",
        contentType: "application/json, charset=utf-8",
        data: JSON.stringify({ actionRequestX: actionRequest }),
        dataType: "json",
        traditional: true,
        success: function (data) {
            // Good stuff
        },
        error: function (data) {
            // Bad stuff
        }
    });
    });
