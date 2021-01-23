	[TestMethod]
	public void FindAll() {
		// Arrange: Create mock source screen and a bunch of mock screen objects that we will use to override (shim) the Screen.AllScreens property getter.
		// TODO: Move this to test class instanciation/setup.
		// A collection of 12 rectangles specifying the custom desktop layout to perform testing on. First one representing the primary screen.
		// In this list we imagine that all screens have the same DPI and that they are frameless.
		// Screens are ordered Primary...Quinternary, those marked ??? have not yet had an 'identifier' assigned to them.
		// Screens are named Primary for in front of user, then left of primary, right of primary, above primary and finally below primary. Closest screen to primary is selected.
		var screenBounds = new Rectangle[] {
			new Rectangle(0, 0, 2560, 1440),			// Primary screen. In front of the user.
			new Rectangle(-1920, 360, 1920, 1080),		// Secondary screen. Immediately left of the Primary screen. Lower edge aligned.
			new Rectangle(2560, 0, 2560, 1440),			// Tertriary screen. Immediately right of the Primary screen.
			new Rectangle(0, -720, 1280, 720),			// Quaternary screen. Immediately above the Primary screen, left aligned.
			new Rectangle(1280, -720, 1280, 720),		// ??? screen. Immediately above the Primary screen, right aligned. (This is side by side with the previous screen)
			new Rectangle(0, -2160, 2560, 1440),		// ??? screen. Above the Quaternary screen and it's neighbor. Spans both those screens.
			new Rectangle(-1920, -920, 960, 1280),		// ??? screen. Above the Secondary screen, tilted 90 degrees, left aligned.
			new Rectangle(-960, -920, 960, 1280),		// ??? screen. Above the Secondary screen, tilted 90 degrees, right aligned. (This is side by side with the previous screen)
			new Rectangle(0, 1440, 640, 480),			// Quinary screen. Immediately below the Primary screen, left aligned.
			new Rectangle(640, 1440, 640, 480),			// ??? screen. Immediately right of the Quinary screen and immediately below the Primary screen. (This is side by side with the previous screen)
			new Rectangle(1280, 1440, 640, 480),		// ??? screen. Immediately below the Primary screen and rigth of the previous screen.
			new Rectangle(1920, 1440, 640, 480),		// ??? screen. Immediately below the Primary screen and rigth of the previous screen.
		};
		// Create a bunch of mock Screen objects.
		var mockAllScreens = new Screen[12];
		var mockScreenBoundsField = typeof(Screen).GetField("bounds", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (mockScreenBoundsField == null)
			throw new InvalidOperationException("Couldn't get the 'bounds' field on the 'Screen' class.");
		var mockScreenPrimaryField = typeof(Screen).GetField("primary", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (mockScreenPrimaryField == null)
			throw new InvalidOperationException("Couldn't get the 'primary' field on the 'Screen' class.");
		var mockScreenHMonitorField = typeof(Screen).GetField("hmonitor", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (mockScreenHMonitorField == null)
			throw new InvalidOperationException("Couldn't get the 'hmonitor' field on the 'Screen' class.");
		// TODO: Currently unused, create a collection of device names to assign from.
		var mockScreenDeviceNameField = typeof(Screen).GetField("deviceName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		if (mockScreenDeviceNameField == null)
			throw new InvalidOperationException("Couldn't get the 'deviceName' field on the 'Screen' class.");
		for (var mockScreenIndex = 0; mockScreenIndex < mockAllScreens.Length; mockScreenIndex++) {
			// Create an uninitialized Screen object.
			mockAllScreens[mockScreenIndex] = (Screen)FormatterServices.GetUninitializedObject(typeof(Screen));
			
			// Set the bounds of the Screen object.
			mockScreenBoundsField.SetValue(mockAllScreens[mockScreenIndex], screenBounds[mockScreenIndex]);
			
			// Set the hmonitor of the Screen object. We need this for the 'Equals' method to compare properly.
			// We don't need this value to be accurate, only different between screens.
			mockScreenHMonitorField.SetValue(mockAllScreens[mockScreenIndex], (IntPtr)mockScreenIndex);
			// If this is the first screen, it is also the primary screen in our setup.
			if (mockScreenIndex == 0)
				mockScreenPrimaryField.SetValue(mockAllScreens[mockScreenIndex], true);
		}
		// Act: Get all screens left of the primary display.
		Collection<Screen> result;
		using (ShimsContext.Create()) {
			ShimScreen.AllScreensGet = () => mockAllScreens;
			result = mockAllScreens[0].FindAll(ScreenSearchDirections.Left);
		}
		// Assert: Compare the result against the picked elements from our mocked screens.
		var expected = new Collection<Screen> { mockAllScreens[1], mockAllScreens[6], mockAllScreens[7] };
		CollectionAssert.AreEqual(expected, result);
	}
