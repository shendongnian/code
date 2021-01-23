    // Setup (used for both tests)
    // Test may be missing setup for dispatcher state == data event disabled.
        _dispatcher.EnqueueDataEvent(new DataEvent(42));
        _dispatcher.EnqueueStatusUpdateEvent(new StatusUpdateEvent(1));
    
    //    Sleep(1000);    // This shouldn’t be in a unit test.
    
    // Test 1 – VerifyThatDataAndStatusEventsDoNotFireWhenDataEventDisabled
        _spy.AssertNoEventsHaveFired();
        _spy.AssertEventsCount(2);
    
    // Test 2 – VerifyThatEnablingDataEventFiresPendingDataEvents
        _serviceObject.SetNumericProperty(PIDX_DataEventEnabled, 1);
    
        _spy.AssertDataEventFired();
        _spy.AssertStatusUpdateEventFired();
    
    // Test 3? – This could be part of Test 2, or it could be a different test to VerifyThatDataEventsAreDisabledOnceADataEventHasBeenTriggered.
        _serviceObject.GetnumericProperty(PIDX_DataEventEnabled).Should().BeEqualTo(0, "because firing a DataEvent sets DataEventEnabled to false");
