    public ActionResult Navigation() {
        var navigations = your query...
        var contents = your other query...
        return View(new NavigationViewModel {
            Navigations = navigations,
            Contents = contents
        });
    }
