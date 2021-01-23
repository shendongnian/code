    var dummy = new DummyStub();
                Foo mockTarget = new Foo(dummy);
    
                mockTarget.DoCalculation();
    
                Func<EventInfo, FieldInfo> eventInfo2FieldInfo = eventInfo => dummy.GetType().GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
                var invocationLists = dummy.GetType().GetEvents().Select(selector => new { Name = selector.Name , Delegate = eventInfo2FieldInfo(selector).GetValue(dummy) as MulticastDelegate } ).ToArray();
    
                var fooBar = invocationLists.FirstOrDefault(predicate => predicate.Name == "DataChanged");
                Assert.IsTrue(fooBar == null || fooBar.Delegate.Target != mockTarget);
