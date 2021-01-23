    <input type="submit" 
               formaction="Save"
               formmethod="post" 
               value="Save" />
        <input type="submit"
               formaction="SaveForLatter"
               formmethod="post" 
               value="Save For Latter" />
        <input type="submit"
               formaction="SaveAndPublish"
               formmethod="post"
               value="Save And Publish" />
    [HttpPost]
    public ActionResult Save(CustomerViewModel model) {...}
    
    [HttpPost]
    public ActionResult SaveForLatter(CustomerViewModel model){...}
    
    [HttpPost]
    public ActionResult SaveAndPublish(CustomerViewModel model){...}
