	[HttpGet]
	//Action method for a new template
	public ActionResult NewTemplate() {
		return New(true, null);
	}
	[HttpGet]
	//Action method for a new project
	public ActionResult New(int? TemplateProjectID) {
		return New(false, TemplateProjectID);
	}
	private ActionResult New(bool IsTemplate, int? TemplateProjectID) {
		//Assorted code follows
