            enum EventType {quit, task};
            class LoopDaLoop {
                Timer _30Seconds_publiser = new Timer(20000);
                Timer _5Seconds_publisher = new Timer(5000);
                Timer _terminator = new Timer(60000);
                BlockingCollection<EventType> loopAEvents = new BlockingCollection<EventType>();
                BlockingCollection<EventType> loopBEvents = new BlockingCollection<EventType>();
                public LoopDaLoop() {
                    _30Seconds_publiser.Elapsed += _30Seconds_publiser_Elapsed;
                    _5Seconds_publisher.Elapsed += _5Seconds_publisher_Elapsed;
                    _terminator.Elapsed += _terminator_Elapsed;
                    _30Seconds_publiser.Start();
                    _5Seconds_publisher.Start();
                    _terminator.Start();
                    Task.Run(() => loopA());
                    Task.Run(() => loopB());
                }
                void _terminator_Elapsed(object sender, ElapsedEventArgs e) {
                    loopAEvents.Add(EventType.quit);
                    loopBEvents.Add(EventType.quit);
                }
                void _5Seconds_publisher_Elapsed(object sender, ElapsedEventArgs e) {
                    loopBEvents.Add(EventType.task);
                }
                void _30Seconds_publiser_Elapsed(object sender, ElapsedEventArgs e) {
                    loopAEvents.Add(EventType.task);
                }
                private void loopA() {
                    while (loopAEvents.Take() != EventType.quit) {
                        // decrypt wife's personal email
                    }
                }
                private void loopB() {
                    while (loopBEvents.Take() != EventType.quit) {
                        // navigate attack drones
                    }
                }
            }
