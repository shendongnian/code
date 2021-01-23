       [NoSlash]
       [Route("robots.txt")]
       public async Task<ActionResult> Robots()
       {
           string robots = getRobotsContent();
           return Content(robots, "text/plain");
        }
