    bundles.Add(new ScriptBundle("Site).Include(
      "~/scripts/jquery.js",
      ));
    // shared across all methods on this controller
    bundles.Add(new ScriptBundle("Controller1").Include(
      "~/scripts/controller1.js"
      ));
    // specific to the view
    bundles.Add(new ScriptBundle("Controller1View1").Include(
      "~/scripts/controller1view1.js"
      ));
