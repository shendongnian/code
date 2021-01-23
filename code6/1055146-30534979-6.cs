    bundles.Add(new ScriptBundle("Site).Include(
      "~/scripts/jquery.js",
      ));
    // shared across all methods on this controller
    bundles.Add(new ScriptBundle("Controller1").Include(
      "~/scripts/controller1.js",
      "~/scripts/controller1View1.js",
      "~/scripts/controller1View2.js"
      ));
