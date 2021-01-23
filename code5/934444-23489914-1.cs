    IConnectableObservable<Person> personPub = personAsObservable.Publish();
    var subscriberOne = personPub.Subscribe(...); // personAsObservable not started
    var connection = personPub.Connect(); // *now* personAsObservable is subscribed
    var subscriberTwo = personPub.Subscribe(...); // shares underlying subscription
                                                  // but could miss events
    connection.Dispose(); // underlying connection terminated
                          // but may have already OnCompleted anyway
                          // in which case this is a no-op
