	protected override void Dispose (bool disposing)
	{
		// TODO: Dispose logic here.
		base.Dispose (disposing);
        GC.Collect(GC.MaxGeneration); // Will force cleanup but not recommended.
	}
	protected override void OnDestroy ()
	{
		if (density != null) { // Release Java objects (buttons, adapters etc) here
			density.Dispose ();
			density = null;
		}
		base.OnDestroy ();
		this.Dispose (); // Sever java binding.
	}
