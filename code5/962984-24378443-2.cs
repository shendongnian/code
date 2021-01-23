    [Route("mysite/{site:values(Site1|Site2)}")]
    public ActionResult Show(string site)
    {
        return Content("from my database " + site);
    }
