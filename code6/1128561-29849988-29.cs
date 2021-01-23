    @model UsefulCode.Models.Person
    <div class="editorRow">
        @using (Html.BeginCollectionItem("teachers"))
        {
            <div class="ui-grid-c ui-responsive">
                <div class="ui-block-a">
                    <span>
                        @Html.TextBoxFor(m => m.firstName)
                    </span>
                </div>
                <div class="ui-block-b">
                    <span>
                        @Html.TextBoxFor(m => m.lastName)
                    </span>
                </div>
                <div class="ui-block-c">
                    <span>
                        <span class="dltBtn">
                            <a href="#" class="deleteRow">X</a>
                        </span>
                    </span>
                </div>
            </div>
        }
    </div>
    Register Controller
    
    public ActionResult Index()
    {
        var register = new Register
        {
            students = new List<Person>
            {
                new Person { firstName = "", lastName = "" }
            },
            teachers = new List<Person> 
            {
                new Person { lastName = "", firstName = "" }
            }
        };
    
        return View(register);
    }
